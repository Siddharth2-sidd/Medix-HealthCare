using AutoMapper;
using HealthcareSystem.DTOs.Claim_DTOs;
using HealthcareSystem.DTOs.Payment_DTOS;
using HealthcareSystem.DTOs.Policy_DTOs;
using HealthcareSystem.DTOs.User_DTOs;
using HealthcareSystem.Models;
namespace HealthcareSystem.Helpers
{
    public class MappingProfile :Profile
    {
        public MappingProfile() {
            CreateMap<User, UserResponseDTOs>();
            CreateMap<Policy, ResponsePolicyDTOs>();
            CreateMap<Claims, ClaimResponseDTOs>();
            CreateMap<Payment, PaymentResponseDTO>();
            CreateMap<UserRegisterDTO, User>();
            CreateMap<CreatepolicyDTOs, Policy>();
            CreateMap<UpdatepolicyDTOs, Policy>();

        }
    }
}
