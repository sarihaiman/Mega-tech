using Microsoft.Extensions.DependencyInjection;

namespace Dto
{
    public class Class1
    {
        public Class1() { }
        public void a(IServiceCollection services) {
            services.AddAutoMapper(typeof(Class1));
        
        
        }  
    }
}
