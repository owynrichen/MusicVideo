The Beat Kitchen Music Video Template
=====================================

This is some code I pulled together to generate some basic music videos for instrumentals my buddy and I write.

The audio code and some of the spectral visualizations were built by following an awesome set of tutorials on YouTube
by Peer Play, here's the first one: https://www.youtube.com/watch?v=4Av788P9stk

The result is an audio visualization that looks like the below image, and can be configured to color switch.

[![Music Video Screenshot](./screenshot.png)](https://www.youtube.com/watch?v=ihMCp84zW2c)

Unity Asset Requirements
========================
* Unity Post Processing Stack - v1.0.4 [https://assetstore.unity.com/packages/essentials/post-processing-stack-83912](https://assetstore.unity.com/packages/essentials/post-processing-stack-83912)
* Unity Recorder - v1.0.2 [https://assetstore.unity.com/packages/essentials/unity-recorder-94079](https://assetstore.unity.com/packages/essentials/unity-recorder-94079)

The above versions are what I've tested it with, it may work with newer versions (Post Processing has a 2.0 in development, for instance).

How-To
======

* Import your audio file into the project.
* In the AudioPeerContainer, there is a reference to the AudioSource, reference your new audio file.
* Also in the AudioPeerContainer, there is a StartSimulation component that identifies a delay time.  This delay time should
be > 0.25 or so because the UnityRecorder component misses the first few frames, so you lose audio without a slight delay.
* With the free UnityRecorder asset installed, you head to the Window > General > Recorder > Recording Window
* Set the start and end times, and hit Start Recording