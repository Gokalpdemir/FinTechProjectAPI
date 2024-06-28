using Serilog.Core;
using Serilog.Events;

namespace FinTechProjectAPI.API.Configurations
{
    public class CustomUserNameColumn : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
          var (username,value)=   logEvent.Properties.FirstOrDefault(u => u.Key == "UserName");
           if(value!=null) {
                LogEventProperty property = propertyFactory.CreateProperty(username, value);
                logEvent.AddPropertyIfAbsent(property);
            }
        }
    }
}
