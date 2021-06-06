using Application.Features.Admins.Commands.Create;
using Application.Features.Admins.Commands.Update;
using Application.Features.Dieticians.Commands.Create;
using Application.Features.Dieticians.Commands.Update;
using Application.Features.DietMethods.Commands.Create;
using Application.Features.DietMethods.Commands.Update;
using Application.Features.Diets.Commands.Create;
using Application.Features.Diets.Commands.Update;
using Application.Features.Diseases.Commands.Create;
using Application.Features.Diseases.Commands.Update;
using Application.Features.Foods.Commands.Create;
using Application.Features.Foods.Commands.Update;
using Application.Features.Patients.Commands.Create;
using Application.Features.Patients.Commands.Update;
using AutoMapper;
using Domain.Entities.Diets;
using Domain.Entities.Diseases;
using Domain.Entities.Persons;

namespace Application.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {

            //* Admin mapping 
            CreateMap<Admin, CreateAdminCommand> ().ReverseMap ();
            CreateMap<Admin, UpdateAdminCommand> ().ReverseMap ();

            //* Dietician mapping 
            CreateMap<Dietician, CreateDieticianCommand> ().ReverseMap ();
            CreateMap<Dietician, UpdateDieticianCommand> ().ReverseMap ();

            //* Patient mapping 
            CreateMap<Patient, CreatePatientCommand> ().ReverseMap ();
            CreateMap<Patient, UpdatePatientCommand> ().ReverseMap ();

            //* Diet mapping 
            CreateMap<Diet, CreateDietCommand> ().ReverseMap ();
            CreateMap<Diet, UpdateDietCommand> ().ReverseMap ();

            //* DietMethod mapping 
            CreateMap<DietMethod, CreateDietMethodCommand> ().ReverseMap ();
            CreateMap<DietMethod, UpdateDietMethodCommand> ().ReverseMap ();

            //* Disease mapping 
            CreateMap<Disease, CreateDiseaseCommand> ().ReverseMap ();
            CreateMap<Disease, UpdateDiseaseCommand> ().ReverseMap ();

            //* Food mapping 
            CreateMap<Food, CreateFoodCommand> ().ReverseMap ();
            CreateMap<Food, UpdateFoodCommand> ().ReverseMap ();

        }
    }
}