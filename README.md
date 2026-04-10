# PhoneToPCPrint

**PhoneToPCPrint** is an Android-to-PC printing system that allows a mobile device to send print jobs directly to a Windows PC over a local network.

The PC runs a **C# (.NET Framework 4.8) server** that receives print tasks, downloads the file locally, and prints it automatically using **SumatraPDF**.

---

## 📌 Important Purpose

THIS PROJECT IS INTENDED FOR PRINTERS THAT DO NOT SUPPORT:
- Phone companion apps
- Wireless printing (Wi-Fi Direct / cloud printing)
- Hotspot printing features
- Bluetooth printing

It is designed as a **bridge solution** that allows modern Android devices to print to **traditional USB or wired printers connected to a PC**.

---

## ⚙️ How It Works

1. The Android app sends a **print task** to the PC server.
2. The task contains a file or file URL.
3. The PC server receives the request.
4. The server downloads the file locally to the PC.
5. **SumatraPDF** is used to silently open and print the file.
6. The document is sent to the default Windows printer automatically.

---

## 🧩 System Architecture

### 📱 Android App (Client)
- Sends print tasks over local Wi-Fi or hotspot
- Provides file upload or file URL

### 💻 PC Server (C# .NET Framework 4.8)
- Receives requests from Android app
- Downloads files locally
- Executes print jobs

### 🖨️ Printing Engine
- SumatraPDF
- Handles PDF/document rendering
- Sends output to Windows printer system
- Supports silent/background printing

---

## 🚀 Features

- Works with non-wireless / non-smart printers
- No printer mobile app required
- Android-to-PC local network printing
- Built using C# (.NET Framework 4.8)
- Automatic file download before printing
- Silent printing using SumatraPDF
- No internet or cloud dependency

---

## 🛠️ Requirements

### 💻 PC (Server)
- Windows OS
- .NET Framework 4.8 installed
- Installed printer (USB or wired)
- SumatraPDF installed
- Local network (Wi-Fi or hotspot)
- Firewall permission for server communication

### 📱 Android (Client)
- Android device
- PhoneToPCPrint app installed
- Same network as PC

---

## 📦 Installation

### 1. Clone repository
```bash
git clone https://github.com/andorrerri/PhoneToPCPrint.git
```

### 2. Open PC Server Project
- Open solution in Visual Studio
- Ensure .NET Framework 4.8

### 3. Install dependencies
- Install SumatraPDF on PC
- Ensure command-line access works

### 4. Build server
- Build solution in Visual Studio

### 5. Run server
- Launch .exe or run from Visual Studio
- Server starts listening for requests

---

## 📱 Usage

1. Start PC server
2. Open Android app
3. Connect both devices to same Wi-Fi/hotspot
4. Send file or text print request
5. Tap Print
6. PC downloads file and prints automatically

---

## ⚠️ Notes

- Server must be running before sending requests
- Devices must be on same network
- Printer must be installed in Windows
- Default printer recommended
- Firewall may require permission

---

## 🔮 Future Improvements

- Authentication system
- Print queue
- Auto server discovery
- More file type support
- Print status feedback

---

## 📄 License

MIT License

---

## 💡 Author

C# (.NET Framework 4.8) Android-to-PC printing bridge using SumatraPDF for silent printing.
