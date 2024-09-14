//Decorator

public abstract class VisualComponent 
{
    public abstract void Draw();
}

public class TextView : VisualComponent
{
    public override void Draw()
    {
        
    }
}

public class Decorator : VisualComponent
{
    Decorator decorator;

    public Decorator(Decorator decorator)
    {
        this.decorator = decorator;
    }

    public override void Draw()
    {
    }
}

public class ScrollDecorator : Decorator 
{
    public ScrollDecorator(Decorator decorator) : base(decorator)
    {
    }

    public override void Draw()
    {
        base.Draw();
    }
}

public class BorderDecorator : Decorator
{
    public BorderDecorator(Decorator decorator) : base(decorator)
    {
    }

    public override void Draw()
    {
        base.Draw();
    }
}

//Composite

class Client
{
    public void Main()
    {
        Component root = new Composite("Root");
        Component leaf = new Leaf("Leaf");
        Composite subtree = new Composite("Subtree");
        root.Add(leaf);
        root.Add(subtree);
        root.Operation();
    }
}
abstract class Component
{
    public string name;

    public Component(string name)
    {
        this.name = name;
    }

    public abstract void Operation();
    public abstract void Add(Component c);
    public abstract void Remove(Component c);

    public abstract Component GetChild(int index);
}
class Composite : Component
{
    public List<Component> children = new List<Component>();

    public Composite(string name): base(name){ }

    public override void Add(Component component)
    {
        children.Add(component);
    }

    public override void Remove(Component component)
    {
        children.Remove(component);
    }

    public override void Operation()
    {
        Console.WriteLine(name);

        foreach (Component component in children)
        {
            component.Operation();
        }
    }

    public override Component GetChild(int index)
    {
        return children[index];
    }
}
class Leaf : Component
{
    public Leaf(string name): base(name){ }

    public override void Operation()
    {
        Console.WriteLine(name);
    }

    public override void Add(Component component)
    {
        throw new NotImplementedException();
    }

    public override void Remove(Component component)
    {
        throw new NotImplementedException();
    }

    public override Component GetChild(int index)
    {
        throw new NotImplementedException();
    }
}


// Bridge
public class Client2 
{
    public void Main() 
    {
        Window window;
        window = new MacWindow(new MacWindowImp());
        window.Draw();
    }
}

public class Window 
{
    protected WindowImp windowImp; 
    public WindowImp WindowImp 
    {
        set 
        {
            windowImp = value; 
        }
    }

    public Window(WindowImp windowImp)
    {
        this.windowImp = windowImp;
    }

    public virtual void Draw()
    {
        windowImp.DevDrawForm();
        windowImp.DevDrawButtom();
    }
}

public class MSWindow : Window
{
    public MSWindow(WindowImp windowImp) : base(windowImp)
    {
    }

    public override void Draw()
    {
    }
}

public class MacWindow : Window
{
    public MacWindow(WindowImp windowImp) : base(windowImp)
    {
    }

    public override void Draw()
    {
    }
}

public abstract class WindowImp
{
    public abstract void DevDrawButtom();
    public abstract void DevDrawForm();
}

public class MSWindowImp : WindowImp
{
    public override void DevDrawButtom()
    {
    }

    public override void DevDrawForm()
    {
    }
}

public class MacWindowImp : WindowImp
{
    public override void DevDrawButtom()
    {
    }

    public override void DevDrawForm()
    {
    }
}