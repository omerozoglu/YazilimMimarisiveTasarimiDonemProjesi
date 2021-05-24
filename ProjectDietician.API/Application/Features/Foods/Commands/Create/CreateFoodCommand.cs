using Domain.Common;
using Domain.Entities.Diets;
using MediatR;

namespace Application.Features.Foods.Commands.Create {

    //* MediatR deseni kullandım
    //*  Komutun gelmesini beklediğimiz tip:Food Komutun döndürmesini istdeiğimiz tip BaseResponse<Food>
    public class CreateFoodCommand : Food, IRequest<BaseResponse<Food>> {

    }
}