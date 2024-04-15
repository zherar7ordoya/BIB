package model;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.image.BufferedImage;
import java.io.File;

import javax.imageio.ImageIO;

import org.w3c.dom.Attr;
import org.w3c.dom.Document;
import org.w3c.dom.Element;

import util.Constants;
import visitor.IVisitor;

public class Picture extends Glyph {

	private BufferedImage image;
	private String fullFilePath;

	/*
	 * public Picture(BufferedImage image){ if (image == null){ throw new
	 * NullPointerException("Image is null"); }
	 * 
	 * this.image = image; }
	 */

	public Picture(String fullFilePath) {
		this.fullFilePath = fullFilePath;
	}

	@Override
	public void draw(Graphics graphics, int x, int y) {
		graphics.drawImage(this.getImage(), x + 3, y, null);
	}

	@Override
	public void select(Graphics graphics, Color hightlightColor,
			Color fontColor, int x, int y) {
		Color previousColor = graphics.getColor();
		graphics.setColor(hightlightColor);
		graphics.drawRect(x, y - 2, this.getImage().getWidth() + 2, this
				.getImage().getHeight() + 2);
		graphics.fillRect(x, y - 2, this.getImage().getWidth() + 2, this
				.getImage().getHeight() + 2);
		graphics.setColor(previousColor);
		this.draw(graphics, x, y);
	}

	@Override
	public int getWidth() {
		return this.getImage().getWidth() + 2;
	}

	@Override
	public int getHeight() {
		return this.getImage().getHeight() + 15;
	}

	@Override
	public void accept(IVisitor visitor) {
		visitor.visitPicture(this);
	}

	@Override
	public void setFont(Font font) {
	}

	@Override
	public Font getFont() {
		return null;
	}

	@Override
	public Element toXmlElement(Document document) {
		Element picElement = document.createElement(Constants.PictureNodeName);

		Attr path = document.createAttribute(Constants.FilePathAttributeName);
		path.setValue(this.fullFilePath);
		picElement.setAttributeNode(path);

		return picElement;
	}

	private BufferedImage getImage() {
		try {
			if (this.image == null) {
				this.image = ImageIO.read(new File(this.fullFilePath));
			}
		} catch (Exception ex) {
			ex.printStackTrace();
		}

		return this.image;
	}
}