// Java program to run the applet using the applet viewer.

import java.applet.Applet;
import java.awt.Graphics;

// Suppressing warning for applet class.
@SuppressWarnings("removal")

public class GfgApplet extends Applet
{
	public void paint(Graphics g) {
        g.drawString("Hello, Gerardo Tordoya!", 20, 20);
    }
}
/*
<applet code="GfgApplet" width=300 height=100>
</applet>
*/
