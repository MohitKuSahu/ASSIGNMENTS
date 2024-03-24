using ParkingManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.DAL
{
    public interface IDAL
    {
        Task<int> AddParkingZoneAsync(ParkingZoneModel model);
        Task<List<ParkingZoneModel>> ListParkingZoneAsync();
        Task<bool> DeleteParkingZoneAsync(int parkingZoneId);

        Task<bool> AddParkingSpaceAsync(ParkingSpaceModel model);
        Task<List<ParkingSpaceModel>> ListParkingSpaceAsync();
        Task<List<ParkingSpaceModel>> ListParkingSpaceByIdAsync(int ParkingZoneId);

        Task<bool> DeleteParkingSpaceAsync(int parkingSpaceId);


        Task<List<VehicleParkingModel>> ListVehicleParkingAsync();

        Task<List<VehicleParkingModel>> ListVehicleParkingByIdAsync(int parkingSpaceId);

        Task<bool> VehicleAsync(VehicleParkingModel model);

        Task<bool> DeleteVehicleParkingAsync(int parkingSpaceId);

        Task<List<ReportModel>> GetParkingReportAsync(DateOnly startDate, DateOnly endDate);

    }
}
