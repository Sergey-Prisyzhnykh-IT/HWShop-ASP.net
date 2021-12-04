﻿using HW2OnlineShop.Time;

namespace HW2OnlineShop
{
    public class ProductCatalog : IProductCatalog
    {
        IRealTime _time;

        public ProductCatalog(IRealTime time)
        {
            _time = time;
        }

        private readonly IReadOnlyCollection<Product> _products = new Product[]
        {
            new ("Куртка", 1000m , 
                "data:image/jpeg;base64,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"
                , "/jacket"),
            new ("Палатка", 25000m, "data:image/jpeg;base64,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"
                ,"/tent"),
            new ("Футболка", 100m, "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBw8ODQ8PDw0NDQ0NDRAODQ0NDw8NDQ4NFREWFhURFRUYHiggGBolGxUVITIhJSkrLi4uFx8zODMsNygtLisBCgoKDQ0NDg0ODi0ZFR0tKysrLSsrKys3KysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrKysrK//AABEIAOEA4QMBIgACEQEDEQH/xAAcAAEAAgMBAQEAAAAAAAAAAAAAAQgCBgcDBAX/xABOEAACAgECAgYCCQ0PBQAAAAAAAQIDBAURByEGEjFBUWFxgRRCUmJykaGxwRMiIyUyM1RkgqPC0dIIFSQ0Q0RFY3SSoqSys8M1U5OU8f/EABQBAQAAAAAAAAAAAAAAAAAAAAD/xAAUEQEAAAAAAAAAAAAAAAAAAAAA/9oADAMBAAIRAxEAPwDuIAAAAAAAAB5ZOTXVHrW2V1QXtrJRhH42B6g0jXeKek4e6WQ8uxJ7V4i+qrfzs5QXxnLekvGDUcpyjjdXApfZ9S2nkNedkly/JS9IHdtb6QYeBDr5eVTjrbdKyaU5fBj2y9SOT9L+Nbadel1OLT55WVBc0u6FW/f4y29Bx7LyrLpuy2yy6yX3Vls5WWS9MpNtnkn4gdKweN+pw++0YV6+BZTJ+tSa+Q2HD49Vv7/pdkfOjIjZ8kox+c4j1F4m18OuiVeq5llN1tlVFONK6dlXUUlJTjFLeSa25v4gOpLjtp23PC1BPyWO/wDkPzNT49R2axdMk33TybowS/Ignv8A3jnvT/oxj6ZmrHx8my+Dx4XSlaobxcpSXV3jsn9zv6zWXSvdAd96JcZ8W9KGo1rCtb5XVqVmK0/HtlD17rzOmafqFGTWrce6q+qXZZTONkX60U4b27D6dP1C/Gn9Uovux7OX19Fk6pcvFxfMC44K99H+MuoY+0cmNWdBe2mlTft8KK2fridJ6PcV9KzGoWWvBuftMvaFbfvbV9b8bT8gN7BhVbGcVKEozhJbxlFqUWvFNGYAAAAAAAAAAAAAAAAA/K6R9IcXTcd35Vqrhv1YR7bLZ7b9SEfbP/6z7s7Lrx6rLrpxrqphKyycntGMIrdtlWenvSieq51mRLrRqX2PGqbf2OhPly7pPtfm/JAbT0n4yZ2RKUcNRwaOxNKNmS14uT5R9S5eJz3P1S/Jl177rb5+6usna/V1nyPhbIAzc2RuYgCQQAJ3PbEzLaZdaq22mXuqpyrl49qZ4EgfTn6hdk2O2+6y+1pRdlsnObS7FuzwTMSUBI3IIAy3JUjEAfs6D0lzdPe+JlXY633dcJdamXPvrlvF/EdT6L8bN3GvUsdJdnsnFT5ecqn+i/UcURKYFxdJ1XHzKY3410L6Z79WyD3W67U12prwfM+wrhwl6afvXlOm+W2DlSirW+yi3sjd6O6Xls+4sdF7rdc0+aa7GgJAAAAAAAAAAAA55xf6bfvbi+xqJ7Z2XBqLj91j0dkrfJvmo+e77gNI409OfZNr03GnvjUT/hdkXyuyIv72n7mL7fGXwefJ7GSzBsCCSAAAAAEkACQAAAAAEoACQAC7SQB6Rkd74JdMfZND06+e+RiQ3xpSfO3FXLq+bhul6GvBnAdz79I1K3EyKcmifUuompwl3brti13prdNeDYFwQfidDuklOq4VeVV9a5fW3VN7ypvX3UH86femmftgAAAAAAAAfndINZp0/Euy75dWqiHWa9tOXZGEfGTbSXpKo9ItZu1DLuy73vbdLfZNuNcFyjXHyS5fL3m8cZ+mPs7M9h0T3w8KbUnF/W35S5Sl5qPOK8+s/A5qwIZiyWQBCJIQAEkEgQASBBIAAAACQAJJRBIAMBgDODMDKIG2cPOmFmkZis3lLEt2hl0rn1od1kV7uO+68Vuu/lZzBzK8iqu6myNtVsFOuyD3jKDW6aKco6Zwh6eewLVhZU9sK+f2OyT5Y10n2vwhJ9vg+fiBYEBAAAABovF7pTPTdO6tLccnNk6KZr+SjtvZZ6UuS83v3G9HyapplGXTKjJprvpn91XZFSjv3NeD81zAp5I82dd6a8HLqetdpknkVdrw7H/CIL+rm+Vi8ns/NnJ8imVc5QnCVdkH1ZwnFwnB+Di+aYHiyDJoxAgHpRRKycK4pynZOMIRS3cpyaSS822j01DDnj320Wrq20WzqsjvvtOMmmt+/mgPnJIRIEEgASAAAAAEgASiSEZADzb5n6eg4ayM7Eokm45GXj0zUeT6k7Yxls/Q2fT006PWaXqF+LNPqxl16Jd1mNJt1y+JNPziwPxEZIwRKYHojNGK7Dp/D7hVdm9TJz1PHw2lKFHOGRkLz764fK/LtA3Lgh0lvy8SzFvhZNYXVjVlNNwlW+ymUu+cf9LXhz6YfPp+DVjVQpoqhTTWurCuuKjGK9B9AAAAAAANf6U9DcDVI7ZWPF2JbQyK/seRBeU12rye68jYABW3pzwtzNN611PWzcJc3ZCP2elf1kF3e+jy8Ujn/VLpGjdI+Fel59yucLMWxy3u9iSjXC7x3i00n75bMDReBvQtztWqZFe1Ve8cGMl98t7JXbeEVuk/Ft9yNF4nY6r17UorseT1/XOEZv5ZMtPh4sKaq6qoRrqqhGuuEeUYQitlFepFZuMUNukGfy7XQ/8ALVAaUAyUAIJIQGQAABAACSCUAMkQzJAbLw2rUtc05P8ACoy9cU2vmO5cUuhC1fEUq9o52KpSx5PssTW8qZPwey2fc9vM4rwqh1te09f1038VFkvoLQgUvnW4txcXGUW4yjJdWUZJ7NNdzT7j9DQtEyc+5UYtE77XtuoL62EX7acnyivNlhulHC7A1HNjlzdtMn/GYUOMY5LS5NvbeMu5tdq+M2vRdGxsGlU4tFdFS9rBc5P3UpPnJ+bbYGjdAuFOPgdTIzOpl5q2lFbb41EveJ/dyXun6kjpAAAAAAAAAAAAAAAAKw8Y5b9IM7ydC/y1RZ4rNxpr6uv5b93DHn+Ygv0QNEZIAAIglASCCQARBkgIMkQSgBnHsMTKAG68Hlvr+F5O9/5a0swVp4OL7f4fksh+r2PZ+sssAAAAAAAAAAAAAAAAAAAArRxrs62v5Xva8eH5mL+ksuVj4yTT1/N27nRH4sar9YGkAnuIAgkgyAglgAQZEIkASiCUBJlWYmVfaBvnBVfb6jypyH+ba+ksiVy4JR+3tfljZD/wpfSWNAAAAAAAAAAAAAAAAAAAAVb4sP7fah5XQ/2Ky0hV3i3X1ekGoedlMl6HjVMDT5EGUjFgQiQgwJDIAEokgkAEAgMjKvtMTKHaB0bgZHfXPg4OQ/8AHUvpLDlf+A8N9ZtfhgXfLbSWAAAAAAAAAAAAAAAAAAAAAVr42w6uv5Hv6cef5pR/RLKFcuOq+3r88LH/ANViA53PtMDKXaQAAIAkIACQABIRBIGRlDtMSYAdX4Aw31LKl4YTXx2w/Ud3OG/ufl/Dsx/ikP8AdO5AAAAAAAAAAAAAAAAAAAAK5cdJb68/e4WOvlsf0ljStXGqzfX8n3lWPH8zGX6QGhMxJIAkgACQABIAAEkEgZIyh2mETKPaB139z7/HM3+y1/7jO4nCf3P89tQyo98sPdfk2x/aO7AAAAAAAAAAAAAAAAAAAAKv8XLOtr+oeVlMfixqi0BVbibPra5qL/Gmv7sIr6ANVIJZAAAACSABJJAAkkgASjMwM4gdI4G39XWkv+7h3w9e8JfoMsMVl4SXuGu4Hvp3QfoePZ9OxZoAAAAAAAAAAAAAAAAAAABU/iFLfWdRf49f8k2voLYFSem9inquoSXY87J+S2S+gD8JkEsxAkAAAABIAAEkEgSjKJijJAbZwzntrenv8ZS+OEl9JaMqvw7/AOs6f/bKvnLUAAAAAAAAAAAAAAAAAAAAKea/Z18zKn7vLyJ+p2ya+cuFLsK261wo1quybjjV5UXOTU6Lq/rk3vv1ZuLXoA58QbNZ0B1mL56VmP4MIz+Zswj0E1h/0Tm+urb52BroNqr4ca3Ls0vI/KlTH55HtHhfrj/oyxem7FX/ACAaeTsbvDhLrj/mUI/CycdfNI+iPB3W3204q9OTH6EBoA2N+lwe1tfyGM/Rkx+lHm+EeuL+aVv0ZNH6wNGSBuz4Ua5+Ar/2Mf8AaMXwr1z8Af8A58b9sDTEZI3JcK9c/APjvxv2z2r4Ta2/5nXH4WRR9EgPzuHT21nT/wC2VfK9i1BxPoHwp1DGz8fKy541NeNarfqcJyutm49i5JRS3257v0HbAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/9k="
                ,"/t-shirt"),
        };

        public IReadOnlyCollection<Product> GetProductCatalog()
        {
            if (_time.GetRealTime().DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
                return _products.Select(it => it with { Price = it.Price * 1.5m }).ToList();
            else
                return _products;

        }
    }
}
