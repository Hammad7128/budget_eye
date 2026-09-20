using System;
using System.Collections.Generic;

namespace budget_eye
{
    public class Configuration
    {
        public int ConfigId { get; set; }
        public decimal ThresholdAmount { get; set; }
        public int SetByAdminId { get; set; }
        public DateTime EffectiveDate { get; set; }
        public bool IsActive { get; set; }

        private static int _configIdCounter = 1;
        private static List<Configuration> _configs = new List<Configuration>();

        public Configuration() { }

        public static void SyncCounterFromDb()
        {
            _configIdCounter = Math.Max(_configIdCounter, DatabaseService.GetMaxConfigId());
        }

        public static Configuration Create(decimal thresholdAmount, int adminId)
        {
            if (thresholdAmount <= 0)
                throw new ArgumentException("Threshold must be greater than 0.");

            if (adminId <= 0)
                throw new ArgumentException("Invalid admin id.");

            DatabaseService.DeactivateAllConfigs();

            for (int i = 0; i < _configs.Count; i++)
            {
                if (_configs[i].IsActive)
                {
                    _configs[i].IsActive = false;
                }
            }

            Configuration config = new Configuration
            {
                ConfigId = _configIdCounter++,
                ThresholdAmount = thresholdAmount,
                SetByAdminId = adminId,
                EffectiveDate = DateTime.Now,
                IsActive = true
            };

            _configs.Add(config);
            DatabaseService.InsertConfiguration(config);

            return config;
        }

        public static Configuration GetActiveConfig()
        {
            for (int i = 0; i < _configs.Count; i++)
            {
                if (_configs[i].IsActive)
                    return _configs[i];
            }

            return null;
        }

        public static decimal GetCurrentThreshold()
        {
            Configuration active = GetActiveConfig();

            if (active != null)
                return active.ThresholdAmount;

            return 10000m;
        }
    }
}
