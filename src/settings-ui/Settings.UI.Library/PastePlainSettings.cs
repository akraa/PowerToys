﻿// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.PowerToys.Settings.UI.Library.Interfaces;

namespace Microsoft.PowerToys.Settings.UI.Library
{
    public class PastePlainSettings : BasePTModuleSettings, ISettingsConfig
    {
        public const string ModuleName = "PastePlain";

        [JsonPropertyName("properties")]
        public PastePlainProperties Properties { get; set; }

        public PastePlainSettings()
        {
            Properties = new PastePlainProperties();
            Version = "1";
            Name = ModuleName;
        }

        public virtual void Save(ISettingsUtils settingsUtils)
        {
            // Save settings to file
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            ArgumentNullException.ThrowIfNull(settingsUtils);

            settingsUtils.SaveSettings(JsonSerializer.Serialize(this, options), ModuleName);
        }

        public string GetModuleName()
            => Name;

        // This can be utilized in the future if the settings.json file is to be modified/deleted.
        public bool UpgradeSettingsConfiguration()
            => false;
    }
}
