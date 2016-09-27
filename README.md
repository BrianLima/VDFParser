# VDFParser
> Provides facilities to parse and write VDF files into managed objects

VDFParser is a small C# library that allows VDF files (specially as Steam's `shortcuts.vdf`) to be parsed and serialized. By now, the only implemented model is the already mentioned `shortcuts` file, but the FSM may be used to parse any other file, as long as the managed model is implemented using the patterns seen in the `VDFEntry` class.

## Parsing

Invoking the static `VDFParser.Parse` method will yield an array of `VDFEntry` instances. You can either provide a file path or a readable generic `Stream` instance:

```C#
VDFParser.VDFParser.Parse("/tmp/shortcuts.vdf");
// => VDFEntry[] { ... }
```

## Serializing

The `VDFSerializer` static class provides a `Serialize` method, that takes a given set of `VDFEntry` instances and returns a `byte` array corresponding to the `shortcuts.vdf` format.

```C#
VDFSerializer.Serialize(new VDFEntry[] { new VDFEntry { Name = "..." } });
// => byte[] { ... }
```

## Other Considerations
It was noticed that Steam's do not follow a standard pattern for naming the fields in the mentioned file. You can find `appname` and `AppName` variations, but it appears that it does not enforce a single naming convention. This library was not extensively tested against multiple Steam installations and, therefore, more information or insights about this behavior is welcome.

## License
```
MIT License

Copyright (c) 2016 Victor Gama

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
```
