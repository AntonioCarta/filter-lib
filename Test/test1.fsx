#r @"C:\Users\Antonio\Dropbox\Code\Visual Studio\ImageFilter\FilterLibC\..\ProvaMEFcsharp\bin\Debug\FilterLibC.dll"
#r @"C:\Users\Antonio\Dropbox\Code\Visual Studio\IUM Final\FilterLibF\bin\Debug\FilterLibF.dll"

open FilterLibC
open FilterLibF
open System.Drawing

#time "on"

let cfil = new FilterLibC.ColorFilter()
let ffil = new FilterLibF.ColorFilter()
let bmp = new Bitmap(@"C:\Users\Antonio\Pictures\2722738-5353872158-255660.jpeg")

//test c colorfilter
//Real: 00:00:00.069, CPU: 00:00:00.078, GC gen0: 0, gen1: 0, gen2: 0          <- 1 iterazione
//Real: 00:00:06.692, CPU: 00:00:08.112, GC gen0: 48, gen1: 48, gen2: 48       <- 100 iterazioni
for i in 1..100 do
  cfil.Apply(bmp) |> ignore


//test f colorfilter
//Real: 00:00:00.255, CPU: 00:00:00.280, GC gen0: 16, gen1: 3, gen2: 1        <- 1 iterazione
//Real: 00:00:24.996, CPU: 00:00:24.554, GC gen0: 1685, gen1: 100, gen2: 100  <- 100 iterazioni
for i in 1..100 do
  ffil.ApplyFilter(bmp)


