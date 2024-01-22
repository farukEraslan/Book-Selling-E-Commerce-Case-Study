namespace BookSeller.Business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly ICartDAL _cartDAL;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CartManager(ICartDAL cartDAL, IMapper mapper, IProductService productService)
        {
            _cartDAL = cartDAL;
            _mapper = mapper;
            _productService = productService;
        }

        public bool AddToCart(CartDomainModel cart, ProductDTO product)
        {
            var productQuantity = _productService.GetById(product.ProductId).Quantity;

            var cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (cartLine != null && cartLine.Quantity < 10)
            {
                cartLine.Quantity++;
                return true;
            }
            else if (cartLine.Quantity < productQuantity)
            {
                return false;
            }
            else if (cartLine == null)
            {
                cart.CartLines.Add(new CartLineDomainModel
                {
                    Product = product,
                    Quantity = 1
                });
                return true;
            }
            else return false;
        }

        public void RemoveFromCart(CartDomainModel cart, Guid productId)
        {
            var cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId);
            if (cartLine != null)
            {
                cartLine.Quantity--;
                if (cartLine.Quantity == 0)
                {
                    cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId));
                }
            }
        }

        public void AddToDatabase(CartDTO cartDTO)
        {
            _cartDAL.Add(_mapper.Map<Cart>(cartDTO));
        }

        public List<CartDTO> GetCarts()
        {
            return _mapper.Map<List<CartDTO>>(_cartDAL.GetAll());
        }

        public CartDTO GetById(Guid cartId)
        {
            return _mapper.Map<CartDTO>(_cartDAL.GetById(x => x.CartId == cartId));
        }

        public void Update(CartDTO cart)
        {
            var updatedCart = _cartDAL.GetById(x => x.CartId == cart.CartId);
            _cartDAL.Update(_mapper.Map(cart, updatedCart));
        }

        public string SendEmail(string customerEmail, string orderId)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            string queueName = "orderConfirmation";
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            string message = $"{customerEmail},{orderId}";
            var body = Encoding.UTF8.GetBytes(message);
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);

             return $"Mesaj gönderildi: {message}";
        }
    }
}
