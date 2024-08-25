using FoodCoupons.core.DL.Entities;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using Services.DTOs;
using DB.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace Services.QRCodeService
{



    public class QrCodeService: IQrCodeService
    {
        private readonly DBContext _dbContext;

        public QrCodeService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private byte[] CreateQrCodeRawData(string payload, int pixelsPerModule)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.H);
            PngByteQRCode pngByteQRCode = new PngByteQRCode(qrCodeData);

            return pngByteQRCode.GetGraphic(pixelsPerModule);
        }

        public string GenerateOrRetrieveQrCode(RequestQrCodeGenerationDto request)
        {
            // Check if a QR code already exists for the EmployeeId
            var existingQrCode = _dbContext.UserQRCodes
                .FirstOrDefault(u => u.EmployeeId == request.EmployeeId && !u.IsDeleted);



            var payload = $"EmployeeId:{request.EmployeeId},FullName:{request.Ar_FullName}";
            var qrCodeData = CreateQrCodeRawData(payload, request.PixelsPerModule);

            if (existingQrCode != null)
            {

                existingQrCode.QRCode = qrCodeData;
                _dbContext.UserQRCodes.Update(existingQrCode);


            }
            else
            {
            
            
          
            // Generate the QR code payload

            // Generate the QR code

            // Save the new QR code to the database
            var userQrCode = new UserQRCode
            {
                EmployeeId = request.EmployeeId,
                QRCode = qrCodeData,
                IsDeleted = false,
                CreatedBy = "System",
                CreatedOn = DateTime.Now

            };

           
            _dbContext.UserQRCodes.Add(userQrCode);

            }

            _dbContext.SaveChanges();

            // Return the new QR code as a base64 string
            return Convert.ToBase64String(qrCodeData);
        }


        public bool SaveScanResult(string employeeId) 
        {

      var user =  _dbContext.Users.FirstOrDefault(x => x.EmployeeId == Convert.ToInt32(employeeId));

            if (user is not null) 
            {

                var scanRecord = new acc_monitor_log()
                {
                    time = DateTime.Now,
                    device_id = 8,
                    device_name = "Main",
                    pin = user.EmployeeId.ToString(),
                    status = false,
                    event_point_id = 2


                };


            _dbContext.acc_Monitor_Logs.Add(scanRecord);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
        


    }



}

