# -*- coding:utf-8 -*-

import os
import shutil

sourceDir = "GeneratedSources"
standardServiceDir = "StandardServices"
nonStandardServiceDir = "NonStandardServices"

standardServices = {
    "Core" : [
        "ALBehaviorManager",
        "ALConnectionManager",
        "ALDiagnosis",
        "ALExpressionWatcher",
        "ALKnowledge",
        "ALMemory",
        "ALMood",
        "ALNotificationManager",
        "ALPreferenceManager",
        "ALResourceManager",
        "ALSystem",
        "ALTabletService",
        "ALUserInfo",
        "ALUserSession",
        "ALWorldRepresentation",
        "PackageManager",
        "ALServiceManager"
        ],
    "Interaction" : [
        "ALAutonomousBlinking",
        "ALAutonomousLife",
        "ALBackgroundMovement",
        "ALBasicAwareness",
        "ALDialog",
        "ALListeningMovement",
        "ALSpeakingMovement"
        ],
    "Motion" : [
        "ALAnimationPlayer",
        "ALMotion",
        "ALNavigation",
        "ALRecharge",
        "ALRobotPosture",
        "ALTracker"
        ],
    "Audio" : [
        "ALAnimatedSpeech",
        "ALAudioDevice",
        "ALSoundDetection",
        "ALSoundLocalization",
        "ALSpeechRecognition",
        "ALTextToSpeech",
        "ALVoiceEmotionAnalysis"
        ],
    "Vision" : [
        "ALBacklightingDetection",
        "ALBarcodeReader",
        "ALCloseObjectDetection",
        "ALColorBlobDetection",
        "ALDarknessDetection",
        "ALLandmarkDetection",
        "ALLocalization",
        "ALMovementDetection",
        "ALPhotoCapture",
        "ALRedBallDetection",
        "ALSegmentation3D",
        "ALVideoDevice",
        "ALVideoRecorder",
        "ALVisionRecognition",
        "ALVisualCompass",
        "ALVisualSpaceHistory"
        ],
    "PeoplePerception" : [
        "ALEngagementZones",
        "ALFaceCharacteristics",
        "ALFaceDetection",
        "ALGazeAnalysis",
        "ALPeoplePerception",
        "ALSittingPeopleDetection",
        "ALWavingDetection"
        ],
    "SensorAndLeds" : [
        "ALBattery",
        "ALBodyTemperature",
        "ALChestButton",
        "ALFsr",
        "ALLaser",
        "ALLeds",
        "ALSensors",
        "ALSonar",
        "ALTactileGesture",
        "ALTouch"
        ],
    "DCM" : ["DCM"]
    }

nonStandardServices = [
    "ALFrameManager",
    "ALPythonBridge",
    ]

def moveCSharpFile(fnameWithoutExtension, srcDir, dstDir):
    fileName = fnameWithoutExtension + ".cs"
    srcFile = os.path.join(srcDir, fileName)
    dstFile = os.path.join(dstDir, fileName)
    shutil.move(srcFile, dstFile)


for dirName, serviceNames in standardServices.items():
    for serviceName in serviceNames:
        moveCSharpFile(
            serviceName, 
            sourceDir, 
            os.path.join(standardServiceDir, dirName)
            )

for serviceName in nonStandardServices:
    moveCSharpFile(serviceName, sourceDir, nonStandardServiceDir)

