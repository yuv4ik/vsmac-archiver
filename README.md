# Archiver

Is a Visual Studio for macOS add-in / extension that let you archive your solution using zip or git.<br/>

## Features

<img src="https://github.com/yuv4ik/vsmac-archiver/raw/master/Graphics/demo.png" width="250"><br/>

Right click on the solution:
* Zip Solution (code only) - zip solution ignoring the next directories:
    * packages/
    * /bin
    * /obj
    * *.git/
    * *.vs/
* Git Archive Solution (HEAD) - git archive solution of the latest commit on the current branch.
   * Please note that at least one commit is required before this option will be available in the context menu.

You can find more information about both methods in my [blogpost](https://smellyc0de.wordpress.com/2018/05/03/archiving-your-code/).

## Installation

### Automatic (pending approval, please use manual installation for now)

You can download and install Archiver using the Extension Manager of Visual Studio for Mac by searching the Gallery.

### Manual

Alternatively you can download and install it manually using the folowing steps:

Download the latest version from [here](https://github.com/yuv4ik/vsmac-archiver/tree/master/Versions). <br/>
Open Visual Studio for macOS and open the "Extensions..." menu<br/>
<img src="https://github.com/yuv4ik/vsmacdeepclean/raw/master/Graphics/0_install.png" width="250"><br/>
Now click on "Install from file" and choose the downloaded mpack<br/>
<img src="https://github.com/yuv4ik/vsmacdeepclean/raw/master/Graphics/1_install.png" width="400"><br/>
It may take few seconds to install.

## Development

### Prerequisites
In order to debug this solution you will have to install [MonoDevelop.AddinMaker](https://github.com/mhutch/MonoDevelop.AddinMaker).

The aim of this project is to practice and experiment with Visual Studio for macOS extensions development.
To play around with this solution just clone this repository and open it with you VS. To build a mpack package, build the solution in Release mode and execute *pack_addin.sh* the output will be redirected to *Versions* directory.

Feel free to share your ideas and contribute.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
