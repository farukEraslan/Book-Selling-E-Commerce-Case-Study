namespace BookSeller.Entity.MapProfiles
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            // Category
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();
            CreateMap<CategoryDTO, Category>().ReverseMap();
            
            // Product
            CreateMap<ProductCreateDTO, Product>();
            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<ProductDTO, Product>().ReverseMap();
            
            // User
            CreateMap<UserCreateDTO, UserEntity>();
            CreateMap<UserUpdateDTO, UserEntity>();
            CreateMap<UserDTO, UserEntity>().ReverseMap();
            
            // Role
            CreateMap<RoleDTO, RoleEntity>().ReverseMap();
        }
    }
}
