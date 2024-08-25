using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs;

namespace Services.QRCodeService
{
    public interface IQrCodeService
    {
        string GenerateOrRetrieveQrCode(RequestQrCodeGenerationDto request);
        bool SaveScanResult(string employeeId);
    }
}
