using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q42.HueApi;
using Q42.HueApi.Interfaces;

namespace YoutubePlaylistPlayer.services
{
    internal class SmartDeviceCommsService
    {
        public SmartDeviceCommsService(string ip)
        {
            SetupLights(ip);
        }

        #region General

        public void SetupLights(string ip)
        {
            //Locate Bridge and Gather Metadata
            FindBridge(ip);
            //Locate Any Other Smart Bulbs (Tuya, Merkury, etc)
        }

        public void CommandLights(string command)
        {

        }

        #endregion

        #region Phillips Hue
        public async void FindBridge(string ip)
        {
            IBridgeLocator locator = new HttpBridgeLocator(); //Or: LocalNetworkScanBridgeLocator, MdnsBridgeLocator, MUdpBasedBridgeLocator
            var bridges = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(20));

            //Advanced Bridge Discovery options:
            bridges = await HueBridgeDiscovery.CompleteDiscoveryAsync(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(30));
            bridges = await HueBridgeDiscovery.FastDiscoveryWithNetworkScanFallbackAsync(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(30));
            bridges = await HueBridgeDiscovery.CompleteDiscoveryAsync(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(15));

            //Register
            ILocalHueClient client = new LocalHueClient(ip);
            //Make sure the user has pressed the button on the bridge before calling RegisterAsync
            //It will throw an LinkButtonNotPressedException if the user did not press the button
            var appKey = await client.RegisterAsync("Seianah App", "MyPC");
            //Save the app key for later use

            client.Initialize("RoxieIsAGoodGirl");
        }

        public void FindPhilipsHueBulbs()
        {

            //if(hueBridge!=null)
            if (true)
            {

            }
        }

        #endregion

        #region Tuya Budget Lightbulbs

        #endregion

        List<SmartDevice> lights = new List<SmartDevice>();
    }

    public class SmartDevice
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Setting { get; set; }
    }
}
