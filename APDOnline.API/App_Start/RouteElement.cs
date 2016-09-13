﻿namespace Online.API.ControllerLess.Configuration
{
    using System.Configuration;

    /// <summary>
    /// The RouteElement class.
    /// </summary>
    public class RouteElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the route URL.
        /// </summary>
        /// <value>
        /// The route URL.
        /// </value>
        [ConfigurationProperty("url", IsRequired = true)]
        public string Url
        {
            get
            {
                return (string)this["url"];
            }

            set
            {
                this["url"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        [ConfigurationProperty("area", DefaultValue = "", IsRequired = false)]
        public string Area
        {
            get
            {
                return (string)this["area"];
            }

            set
            {
                this["area"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        /// <value>
        /// The controller.
        /// </value>
        [ConfigurationProperty("controller", DefaultValue = "ControllerLess", IsRequired = false)]
        public string Controller
        {
            get
            {
                return (string)this["controller"];
            }

            set
            {
                this["controller"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        [ConfigurationProperty("action", DefaultValue = "Index", IsRequired = false)]
        public string Action
        {
            get
            {
                return (string)this["action"];
            }

            set
            {
                this["action"] = value;
            }
        }
    }
}
