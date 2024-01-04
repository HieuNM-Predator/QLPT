using Azure;
using QLPT_API.Entities;
using QLPT_API.Handles.DTOs;
using QLPT_API.Handles.Request.AuthRequest;
using QLPT_API.Handles.Response;

namespace QLPT_API.Services.IService
{
    public interface IAuthService
    {
        ResponseObject<PhatTuDTO> Register(Request_Register request);
        ResponseObject<TokenDTO> Login(Request_Login request);
        ResponseObject<PhatTuDTO> ConfirmActiveAccount(Request_ConfirmActiveAccount request);
        TokenDTO GenerateAccessToken(PhatTu phatTu);
        string GenerateRefreshToken();
        ResponseObject<TokenDTO> RenewAccessToken(TokenDTO request);
        string ForgotPasword(Request_ForgotPassword request);
        ResponseObject<PhatTuDTO> ConfirmCreateNewPassword(Request_ConfirmCreateNewPassword request);
        string ChangePassword(int phatTuId, Request_ChangePassword request);
        
    }
}
