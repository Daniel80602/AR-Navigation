# AR Navigation For Library
## Overview
Augmented Reality (AR) is a technology that blends digital elements with the real-world environment through devices like smartphones, tablets, etc.
AR based Library Navigation System is an final year project created for our college library for AR experience on campus by our group. It is a marker based Navigation system.

## Software & Tools Used
### 1. Unity
**Description:**  
Unity is a cross-platform game engine used for creating interactive this AR based Application. It provides various tools and a strong development foundation to develop the project.
This is the setup of the working environment in unity. This application was made for Android devices only.
![unity](https://github.com/Daniel80602/AR-Navigation/assets/110182355/2ebb475b-4b70-4b8f-af62-9b3d55d780f9)

### 2. Revit
**Description:**  
We chose Revit due to our familiarity with the software, despite there being multiple alternatives. It was used to create both 2D and 3D maps of our library. 
The measurements for the library were physically taken by us using a measuring tape, as no prior blueprints or floor maps of the library were available.

![revit](https://github.com/Daniel80602/AR-Navigation/assets/110182355/8a3a8266-b257-48a1-8409-9adb8be31797)

### 3. Zxing
At the initial stages of the project Vuforia was used but due to its computational inefficiency an alternative solution was chosen that is the Zxing library.It was used to scan and decode the markers.
The library link is provided below:-
- https://github.com/micjahn/ZXing.Net

### 4. ARCore & ARFoundation
ARCore is Google's platform for building augmented reality experiences on Android devices. It enables us to create immersive and interactive
AR applications by providing tools to detect the position and orientation of the device,etc in the environment.
ARFoundation is a framework developed by Unity that enables the creation of augmented reality applications across multiple platforms, including ARCore for Android and ARKit for IOS.
It provides functionalities for plane detection, image tracking, 3D object tracking, and more, making it easier to build complex AR experiences.
Find more detail in the below link:-
- https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@5.0/manual/index.html

### 5. Navmesh
Navmesh is an crucial component to provide the navigational prowess to the application.It uses A* algorithm which provides the most effiecient path in the environment to the target location.

## Flow & System Design
### The below image is the basic system Architecture:-
![architecture](https://github.com/Daniel80602/AR-Navigation/assets/110182355/425177aa-76f3-4625-929e-dfd9d30aa945)

### The below image is the flow of the system:-
![design](https://github.com/Daniel80602/AR-Navigation/assets/110182355/2462c71c-3162-4f6c-a0aa-6876914d3ea1)


## Features of the application
- Simplify library navigation for users
- Find and display the shortest path to the desired book
- Visualize the path using Augmented Reality (AR)
- Generate revenue through virtual ads(Event promotion etc)


# Output

This is an screen recording of the working of the application in real time.

https://github.com/Daniel80602/AR-Navigation/assets/110182355/4278d4f4-dc31-41a1-b1ad-e4e9d4d68b22

# Conclusion
”AR In Library Navigation System” offers a sophisticated solution for optimizing navigation within the college library. Seamlessly integrating augmented reality (AR) technology,
the app enhances user experience and efficiency. Users can easily locate books through virtual content display, augmenting traditional library navigation with intuitive digital overlays.
The system enriches the college atmosphere by dynamically augmenting banners of ongoing
events, fostering community engagement. 

