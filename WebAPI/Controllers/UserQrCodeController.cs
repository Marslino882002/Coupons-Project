using DB.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.QRCodeService;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserQrCodeController : ControllerBase
{
    private readonly IQrCodeService _qrCodeService;


    public UserQrCodeController(IQrCodeService qrCodeService)
    {
        _qrCodeService = qrCodeService;
        
    }

    [HttpPost("generate-multiple")]
    public IActionResult GenerateMultipleQrCodes([FromBody] List<RequestQrCodeGenerationDto> qrCodeRequests)
    {
        var qrCodes = new List<object>(); // Store the base64 QR codes along with EmployeeId for response

        foreach (var request in qrCodeRequests)
        {
            if (string.IsNullOrWhiteSpace(request.Payload))
            {
                continue; // Skip invalid payloads
            }

            // Use the service to either retrieve an existing QR code or generate a new one
            var qrCodeBase64 = _qrCodeService.GenerateOrRetrieveQrCode(request);

            qrCodes.Add(new
            {
                EmployeeId = request.EmployeeId,
                QrCode = qrCodeBase64
            });
        }

        return Ok(new { qrCodes });
    }

    [HttpPost]
    public IActionResult SaveScanResult ([FromBody] string employeeId)
    {
        
        
     var result =  _qrCodeService.SaveScanResult(employeeId); 

        return Ok (result);
    }

}




