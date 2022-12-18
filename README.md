From SO question https://stackoverflow.com/q/74829576/1303323

A possible solution for moving a WinForms form without mouse drag. The main points are:

- Utilizing the `IMessageFilter`
- Laying out a set of transparent windows on all screens in order to receive mouse move messages everywhere.

Pros
- It works without having to make any P/Invokes
- It allows more tricks to be done like for example leverage the transparent forms to implement a "move border instead of form" functionality (though I didn't test it, paint might be tricky)
- Can be easily applied for resize as well.
- Can work with mouse buttons other than the left/primary.

Cons
- It has too many "moving parts". At least for my taste. Laying out transparent windows all over the place? Hm.
- It has some corner cases. Pressing <kbd>Alt</kbd>+<kbd>F4</kbd> while moving the form will close the "canvas form". That can be easily mitigated but there might be others as well.
- There *must* be an OS way to do this...
