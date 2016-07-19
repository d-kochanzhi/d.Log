# d.Log
Сервис логирования для SharePoint
```
 class LoggingService
    {
        private static LoggingService _current;

        public ILog Logger = new LogAggregator(new ILog[]{new SPLogger(), new DebugLogger(), }){ ApplicationName = "Мой проект"};

        /// <summary>
        /// Текущий экземпляр
        /// </summary>
        public static LoggingService Current
        {
            get
            {
                if (_current == null)
                    _current = new LoggingService();
                return _current;
            }
        }
    }	
```

Использование

```
 LoggingService.Current.Logger.Info("Hello world"));
```