Socket.IO Server for Qi Framework

## About

The script "qimessaging-json.py" works as a Socket.IO (0.9.x) server to connect 
Socket.IO client and the qi Framework server, in words, the robot.

There is NO my originality in the script.
At any time, you can download "qimessaging-json" from the Aldebaran's official repository, 
and rename to "qimessaging-json.py".

Repository: https://github.com/aldebaran/libqi-js


## System Requirement

- Python 2.7.x 32bit
- Tornadio 2 (you can get it by pip, just type 'pip install tornadio2')
- qi library for Python. you can get qi for Python in
    * JP https://community.ald.softbankrobotics.com/ja/developerprogram
	* EN https://community.ald.softbankrobotics.com/en/developerprogram


## Usage

1. Check that the Python environment is set to "Python 2.7"
2. Open this project's property
3. Choose `Script Arguments`, and input the IP address of your robot, or some other qi framework server.
4. Run without debug.

Off course you can also operate it by "cmd.exe", if you know what you do.

## Hint

If you can run the robot's simulator in this PC (it means you have your simulated robot in 127.0.0.1), 
you should do so for the environment simplicity.
