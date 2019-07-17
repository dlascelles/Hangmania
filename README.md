# Hangmania

A Hangman game built using C#, WPF and the MVVM pattern.

The game can be played in 3 different modes:

#### Ten Word Game Mode
You go through guessing a total of ten words and try to achieve the maximum score possible.

![TenWord Game Mode](https://user-images.githubusercontent.com/52032313/59856214-2147e400-937f-11e9-86d0-cc128fd265ae.jpg)

#### Timed Game Mode
You have five minutes to guess as many words as possible.

![Timed Game Mode](https://user-images.githubusercontent.com/52032313/59856210-1ee58a00-937f-11e9-91f6-2157cb8ae7ad.jpg)

#### Infinite Game Mode
You keep guessing words until  you miss one. As soon as you miss a word the game ends.

![Infinite Game Mode](https://user-images.githubusercontent.com/52032313/59856195-19883f80-937f-11e9-8a4d-02562c702f90.jpg)


If at any point during the game, you think you know the word, then you can try and type it all at once in the text-box above the letters to get more points, but if you don't find it then you will lose more points instead.

There are more than 50.000 English words inside the database file and more than 100.000 Greek words.


# Dependencies
The application is build using the .NET Framework 4.6.0.

# Acknowledgments
The application makes use of the following:
* The [MVVM Light Toolkit]
* The [Mahapps Metro] UI kit for WPF
* Josh Smith's [Thriple Library] for WPF
* The stickman images from [OpenClipart-Vectors]

# License
MIT License

Copyright (c) 2017 Daniel Lascelles

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

[MVVM Light Toolkit]: <http://www.mvvmlight.net/>
[Mahapps Metro]: <http://mahapps.com/>
[Thriple Library]: <http://thriple.codeplex.com/>
[OpenClipart-Vectors]: <https://pixabay.com/en/users/OpenClipart-Vectors-30363/>