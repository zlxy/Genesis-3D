// cs0722.cs: `StaticClass': static types cannot be used as return types
// Line: 8

static class StaticClass {
}

class MainClass {
    public static StaticClass Method ()
    {
        return null;
    }
}
