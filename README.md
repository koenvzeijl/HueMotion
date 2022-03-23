HueMotion
=========

This is a sample project to show you how you can talk to your local bridge and request Hue Motion data via the api. This motion data is then shown on the website and refreshed every 20 seconds.

To make this work for your own project, please adjust the change the following appsettings in the appsettings.json:

```json
  ...,
  "HueApi": {
    "BridgeIp": "YOUR_BRIDGE_ID",
    "ApplicationKey": "YOUR_APPLICATION_KEY"
  },
  ...
```

For more Philips Hue guides and project check out [MoreHue.com](https://morehue.com/) 