using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HueApi;
using HueApi.BridgeLocator;
using HueApi.Models;
using Q42.HueApi;
using Q42.HueApi.Interfaces;

namespace YoutubePlaylistPlayer.services
{
    internal class SmartDeviceCommsService
    {
        public SmartDeviceCommsService()
        {
            SetupLights();
        }

        #region General

        public void SetupLights()
        {
            //Locate Bridge and Gather Metadata
            FindBridge();
            FindPhilipsHueBulbs();

            //Locate Any Other Smart Bulbs (Tuya, Merkury, etc)
        }

        public void CommandLights()
        {

        }

        #endregion

        #region Phillips Hue
        public async void FindBridge()
        {
            IBridgeLocator locator = new HttpBridgeLocator();
            var bridges = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));
            var bridge = bridges.FirstOrDefault();

            Console.WriteLine(bridge.IpAddress);

            ILocalHueClient client = new LocalHueClient(bridge.IpAddress);
            //Make sure the user has pressed the button on the bridge before calling RegisterAsync
            //It will throw an LinkButtonNotPressedException if the user did not press the button
            var appKey = await client.RegisterAsync("SeianahPlayerApp", "NicholasEubanksPC"); //Store this info somewhere...
            //Save the app key for later use

        }

        public void FindPhilipsHueBulbs()
        {
            var localHueApi = new LocalHueApi("BRIDGE_IP", "KEY");

            //if(hueBridge!=null)
            if (true)
            {

            }
        }

        #endregion

        #region Tuya Budget Lightbulbs

        #endregion

        List<SmartDevice> lights = new List<SmartDevice>();
        LocatedBridge bridge = null;
    }

    public class SmartDevice
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Setting { get; set; }
    }
}
