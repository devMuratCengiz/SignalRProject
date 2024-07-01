using AutoMapper;
using SignalR.DTO.Dtos.AboutDtos;
using SignalR.DTO.Dtos.BookingDtos;
using SignalR.DTO.Dtos.CategoryDtos;
using SignalR.DTO.Dtos.ContactDtos;
using SignalR.DTO.Dtos.DiscountDtos;
using SignalR.DTO.Dtos.FeatureDtos;
using SignalR.DTO.Dtos.ProductDtos;
using SignalR.DTO.Dtos.SocialMediaDtos;
using SignalR.DTO.Dtos.TestimonialDto;
using SignalR.Entity.Entities;

namespace SignalRAPI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();

            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
            CreateMap<Booking, ResultBookingDto>().ReverseMap();

            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, ResultContactDto>().ReverseMap();

            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();

            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();

            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();

            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
        }
    }
}
