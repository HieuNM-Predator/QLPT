using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using QLPT_API.Entities;
using QLPT_API.Handles.Converters;
using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Request;
using QLPT_API.Handles.Request.AuthRequest;
using QLPT_API.Handles.Response;
using QLPT_API.Helper;
using QLPT_API.Services.IService;
using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Mail;
using System.Numerics;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace QLPT_API.Services.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext context;
        private readonly ResponseObject<PhatTuDTO> responseObject;
        private readonly PhatTuConverter phatTuConverter;
        private readonly IConfiguration configuration;
        private readonly ResponseObject<TokenDTO> responseObjectToken;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthService(ResponseObject<PhatTuDTO> responseObject, PhatTuConverter phatTuConverter, IConfiguration configuration,
            ResponseObject<TokenDTO> responseObjectToken,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor)
        {
            this.context = new AppDbContext();
            this.responseObject = responseObject;
            this.phatTuConverter = phatTuConverter;
            this.configuration = configuration;
            this.responseObjectToken = responseObjectToken;
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }

        // Đăng nhập
        public ResponseObject<TokenDTO> Login(Request_Login request)
        {
            if (string.IsNullOrWhiteSpace(request.TenTaiKhoan) || string.IsNullOrWhiteSpace(request.MatKhau))
            {
                responseObjectToken.Status = StatusCodes.Status400BadRequest;
                responseObjectToken.Data = null;
                responseObjectToken.Message = "Vui lòng nhập đầy đủ tên tài khoản và mật khẩu";
                return responseObjectToken;
            }

            var phatTu = context.PhatTu.FirstOrDefault(x => x.TenTaiKhoan == request.TenTaiKhoan && x.MatKhau == request.MatKhau);
            if (phatTu is null) 
            {
                responseObjectToken.Status = StatusCodes.Status404NotFound;
                responseObjectToken.Data = null;
                responseObjectToken.Message = "Tài khoản hoặc mật khẩu sai! ";
                return responseObjectToken;
            }
            if(phatTu.isActive == false)
            {
                responseObjectToken.Status = StatusCodes.Status400BadRequest;
                responseObjectToken.Data = null;
                responseObjectToken.Message = "Tài khoản chưa kích hoạt";
                return responseObjectToken;
            }

            // Cấp token
            var token = GenerateAccessToken(phatTu);

            responseObjectToken.Status = StatusCodes.Status200OK;
            responseObjectToken.Data = token;
            responseObjectToken.Message = "Đăng nhập thành công";
            return responseObjectToken;
        }

        // Đăng ký
        public ResponseObject<PhatTuDTO> Register(Request_Register request)
        {
            #region validate
            if (string.IsNullOrWhiteSpace(request.TenTaiKhoan) ||
                string.IsNullOrWhiteSpace(request.MatKhau) ||
                string.IsNullOrWhiteSpace(request.PhapDanh) ||
                string.IsNullOrWhiteSpace(request.SoDienThoai) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.GioiTinh) ||
                string.IsNullOrWhiteSpace(request.ChuaId.ToString()))
            {
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                responseObject.Message = "Bạn cần điền đẩy đủ thông tin";
                return responseObject;
            }

            if (!InputHelper.IsEmail(request.Email))
            {
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                responseObject.Message = "Email không hợp lệ";
                return responseObject;
            }

            if (context.PhatTu.FirstOrDefault(x => x.TenTaiKhoan == request.TenTaiKhoan) != null)
            {
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                responseObject.Message = "Tên tài khoản đã tồn tại";
                return responseObject;
            }

            if (context.PhatTu.FirstOrDefault(x => x.Email == request.Email) != null)
            {
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                responseObject.Message = "Email đã tồn tại";
                return responseObject;
            }

            if (context.PhatTu.FirstOrDefault(x => x.SoDienThoai == request.SoDienThoai) != null)
            {
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                responseObject.Message = "Số điện thoại đã tồn tại";
                return responseObject;
            }

            if(context.Chua.FirstOrDefault(x => x.Id == request.ChuaId) == null)
            {
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Data = null;
                responseObject.Message = "Chùa không tồn tại";
                return responseObject;
            }

            //Ảnh chụp
            var allowedExtension = new string[] { ".jpg", ".jepg", ".png" };
            if (allowedExtension.Contains(Path.GetExtension(request.AnhChup.FileName)) == false)
            {
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                responseObject.Message = "Ảnh không đúng định dạng";
                return responseObject;
            }

            if (request.AnhChup.Length > 10485760)
            {
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                responseObject.Message = "Dung lượng không quá 10MB";
                return responseObject;
            }
            if (request.AnhChup == null || request.AnhChup.Length == 0)
            {
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                responseObject.Message = "Bạn cần chọn ảnh";
                return responseObject;
            }

            #endregion

            // xử lý ảnh
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{request.AnhChup.FileName}");
            //upload image to localpath
            using var stream = new FileStream(localFilePath, FileMode.Create);
            request.AnhChup.CopyTo(stream);
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{request.AnhChup.FileName}";

            // Thêm mới phật tử
            PhatTu phatTu = new PhatTu();
            phatTu.PhapDanh = request.PhapDanh;
            phatTu.TenTaiKhoan = request.TenTaiKhoan;
            phatTu.MatKhau = request.MatKhau;
            phatTu.Email = request.Email;   
            phatTu.NgaySinh = request.NgaySinh;
            phatTu.GioiTinh = request.GioiTinh;
            // Ảnh
            phatTu.AnhChup = urlFilePath;
            phatTu.SoDienThoai = request.SoDienThoai;
            phatTu.DaHoanTuc = request.DaHoanTuc;
            phatTu.NgayHoanTuc = request.NgayHoanTuc;
            phatTu.ChuaId = request.ChuaId;
            phatTu.QuyenHanId = 1;
            context.Add(phatTu);
            context.SaveChanges();


            ConfirmEmail connfirmEmail = new ConfirmEmail()
            {
                PhatTuId = phatTu.Id,
                DaXacNhan = false,
                ThoiGianHetHan = DateTime.Now.AddHours(24),
                MaXacNhan = GenerateCode().ToString(),
            };
            context.ConfirmEmail.Add(connfirmEmail);
            context.SaveChanges();

            string message = SendMail(new Email_Request
            {
                To = request.Email,
                Subject = "Nhận mã xác nhận để xác nhận đăng ký tài khoản mới từ đây: ",
                Content = $"Mã kích hoạt của bạn là: {connfirmEmail.MaXacNhan}, hiệu lực trong 24 tiếng"
            });

            responseObject.Status = StatusCodes.Status200OK;
            responseObject.Data = phatTuConverter.EntityToDTO(phatTu);
            responseObject.Message = "Gửi dc mail";
            return responseObject;
        }

        //private ResponseObject<PhatTuDTO> ValidateFileUpload(IFormFile AnhChup)
        //{
        //    var allowedExtension = new string[] { ".jpg", ".jepg", ".png" };
        //    if (allowedExtension.Contains(Path.GetExtension(AnhChup.FileName)) == false)
        //    {
        //        responseObject.Status = StatusCodes.Status400BadRequest;
        //        responseObject.Data = null;
        //        responseObject.Message = "Ảnh không đúng định dạng";
        //        return responseObject;
        //    }

        //    if (AnhChup.Length > 10485760)
        //    {
        //        responseObject.Status = StatusCodes.Status400BadRequest;
        //        responseObject.Data = null;
        //        responseObject.Message = "Dung lượng không quá 10MB";
        //        return responseObject;
        //    }
        //}

        // Tạo code xác nhận mail
        private int GenerateCode()
        {
            Random random = new Random();
            return random.Next(100000, 1000000);
        }

        // Xác nhận tài khoản mới
        public ResponseObject<PhatTuDTO> ConfirmActiveAccount(Request_ConfirmActiveAccount request)
        {
            ConfirmEmail confirmEmail = context.ConfirmEmail.FirstOrDefault(x => x.MaXacNhan == request.MaXacNhan);
            if (confirmEmail == null)
            {
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                responseObject.Message = "Mã xác thực không tồn tại";
                return responseObject;
            }
            if (confirmEmail.ThoiGianHetHan < DateTime.Now)
            {
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                responseObject.Message = "Mã xác thực hết hiệu lực";
                return responseObject;
            }

            PhatTu phatTu = context.PhatTu.FirstOrDefault(x => x.Id == confirmEmail.PhatTuId);
            phatTu.isActive = true;
            context.PhatTu.Update(phatTu);
            context.ConfirmEmail.Remove(confirmEmail);
            context.SaveChanges();

            responseObject.Status = StatusCodes.Status200OK;
            responseObject.Data = null;
            responseObject.Message = "Tài khoản đã được kích hoạt thành công. Đăng nhập để sử dụng dịch vụ";
            return responseObject;
        }

        // Quên mật khẩu
        public string ForgotPasword(Request_ForgotPassword request)
        {
            PhatTu phatTu = context.PhatTu.FirstOrDefault(x => x.Email == request.Email);
            if (phatTu == null)
            {
                return "Email không tồn tại";
            }
            else
            {

                ConfirmEmail confirmEmail = new ConfirmEmail()
                {
                    PhatTuId = phatTu.Id,
                    DaXacNhan = false,
                    ThoiGianHetHan = DateTime.Now.AddMinutes(30),
                    MaXacNhan = GenerateCode().ToString(),
                };
                context.ConfirmEmail.Add(confirmEmail);
                context.SaveChanges();

                string message = SendMail(new Email_Request
                {
                    To = request.Email,
                    Subject = "Mã xác nhận tạo mật khẩu mới",
                    Content = $"Mã xác nhận: {confirmEmail.MaXacNhan}, hiệu lực 30 phút"
                });

                return "Gửi mã xác nhận về email, vui lòng kiểm tra";
            }
        }

        // Xác nhận mật khẩu mới
        public ResponseObject<PhatTuDTO> ConfirmCreateNewPassword(Request_ConfirmCreateNewPassword request)
        {
            ConfirmEmail confirmEmail = context.ConfirmEmail.FirstOrDefault(x => x.MaXacNhan == request.MaXacNhan && x.DaXacNhan == false);
            if(confirmEmail == null)
            {
                responseObject.Status = StatusCodes.Status404NotFound;
                responseObject.Data = null;
                responseObject.Message = "Mã xác nhận không hợp lệ";
                return responseObject;
            }
            if(confirmEmail.ThoiGianHetHan < DateTime.Now)
            {
                responseObject.Status = StatusCodes.Status400BadRequest;
                responseObject.Data = null;
                responseObject.Message = "Mã xác nhận đã hết hạn";
                return responseObject;
            }

            PhatTu phatTu = context.PhatTu.FirstOrDefault(x => x.Id == confirmEmail.PhatTuId);
            phatTu.MatKhau = request.MatKhauMoi;
            context.PhatTu.Update(phatTu);
            context.ConfirmEmail.Remove(confirmEmail);
            context.SaveChanges();
            responseObject.Status = StatusCodes.Status200OK;
            responseObject.Data = phatTuConverter.EntityToDTO(phatTu);
            responseObject.Message = "Đổi mật khẩu thành công";
            return responseObject;
        }

        // Đổi mật khẩu
        public string ChangePassword(int phatTuId, Request_ChangePassword request)
        {
            PhatTu phatTu = context.PhatTu.FirstOrDefault(x => x.Id == phatTuId);
            if(phatTu.MatKhau != request.MatKhauCu)
            {
                return "Mật khẩu cũ không đúng";
            }
            if(request.MatKhauMoi != request.XacNhanMatKhauMoi)
            {
                return "Xác nhận mật khẩu không chính xác";
            }
            phatTu.MatKhau = request.MatKhauMoi;
            context.PhatTu.Update(phatTu);
            context.SaveChanges();
            return "Đổi mật khẩu thành công";
        }

        public TokenDTO GenerateAccessToken(PhatTu phatTu)
        {
            QuyenHan quyen = context.QuyenHan.FirstOrDefault(x => x.Id == phatTu.QuyenHanId);
            string role = quyen.TenQuyenHan;
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKey = System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, phatTu.PhapDanh),
                    new Claim(ClaimTypes.Email, phatTu.Email),
                    new Claim("TenTaiKhoan", phatTu.TenTaiKhoan),
                    new Claim("Id", phatTu.Id.ToString()),
                    //Quyền
                    new Claim(ClaimTypes.Role, role)

                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha512Signature),
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            //Lưu refresh token
            var resfreshTokenEntity = new RefreshToken()
            {
                PhatTuId = phatTu.Id,
                Token = refreshToken,
                ThoiGianHetHan = DateTime.UtcNow.AddHours(1),
            };

            context.Add(resfreshTokenEntity);
            context.SaveChanges();

            TokenDTO tokenDTO = new TokenDTO
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };
            return tokenDTO;
        }

        public string GenerateRefreshToken()
        {
            var random = new byte[32];
            using( var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);

                return Convert.ToBase64String(random);
            }
        }

        public ResponseObject<TokenDTO> RenewAccessToken(TokenDTO request)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value);
            var tokenValidateParam = new TokenValidationParameters
            {
                // tự cấp token
                ValidateIssuer = false,
                ValidateAudience = false,
                // ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = false,  // không kiểm tra token hết hạn
            };

            try
            {
                // check AccessToken valid format
                var tokenInVerification = jwtTokenHandler.ValidateToken(request.AccessToken, tokenValidateParam, out var validatedToken);

                // check algorithm
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
                    if(!result) // False
                    {
                        responseObjectToken.Status = StatusCodes.Status400BadRequest;
                        responseObjectToken.Data = null;
                        responseObjectToken.Message = "Token không hợp lệ";
                        return responseObjectToken;
                    }
                }

                // check accessToken expired?
                var utcExpiredDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

                var expiredDate = ConvertUnixTimeToDateTime(utcExpiredDate);
                if(expiredDate > DateTime.Now)
                {
                    responseObjectToken.Status = StatusCodes.Status400BadRequest;
                    responseObjectToken.Data = null;
                    responseObjectToken.Message = "Token chưa hết hạn";
                    return responseObjectToken;
                }

                // check refreshtoken exist in DB
                var storedToken = context.RefreshToken.FirstOrDefault(x => x.Token == request.RefreshToken);
                if ( storedToken == null)
                {
                    responseObjectToken.Status = StatusCodes.Status404NotFound;
                    responseObjectToken.Data = null;
                    responseObjectToken.Message = "Token không tồn tại";
                    return responseObjectToken;
                }

                // check user
                var phatTu = context.PhatTu.FirstOrDefault(x => x.Id == storedToken.PhatTuId);
                if ( phatTu == null )
                {
                    responseObjectToken.Status = StatusCodes.Status404NotFound;
                    responseObjectToken.Data = null;
                    responseObjectToken.Message = "Người dùng không tồn tại";
                    return responseObjectToken;
                }

                // Create new token
                var token = GenerateAccessToken(phatTu);

                responseObjectToken.Status = StatusCodes.Status200OK;
                responseObjectToken.Data = token;
                responseObjectToken.Message = "Làm mới token thành công";
                return responseObjectToken;
            }
            catch (Exception ex)
            {
                responseObjectToken.Status = StatusCodes.Status400BadRequest;
                responseObjectToken.Data = null;
                responseObjectToken.Message = "Token không hợp lệ";
                return responseObjectToken;
            }
        }

        private DateTime ConvertUnixTimeToDateTime(long utcExpiredDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExpiredDate).ToUniversalTime();

            return dateTimeInterval;
        }

        private string SendMail(Email_Request email_Request)
        {
            try
            {
                string provider = configuration.GetSection("MailSettings:Provider").Value.ToString();
                int port = int.Parse(configuration.GetSection("MailSettings:port").Value.ToString());
                string defaultSender = configuration.GetSection("MailSettings:DefaultSender").Value.ToString();
                string password = configuration.GetSection("MailSettings:Password").Value.ToString();
                SmtpClient smtpClient = new SmtpClient(provider, port);
                smtpClient.Credentials = new NetworkCredential(defaultSender, password);
                smtpClient.EnableSsl = true;


                MailMessage message = new MailMessage();
                message.From = new MailAddress(defaultSender);
                message.To.Add(email_Request.To);
                message.Subject = email_Request.Subject;
                message.Body = email_Request.Content;

                smtpClient.Send(message);
                return "Gửi mail thành công";
            }
            catch (Exception ex)
            {
                return "Lỗi khi gửi email: " + ex.Message;
            }

        }
    }
}
