using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace FYJ.Winform.Util
{
	
	/// <summary>
	/// HueModifier modifies Hue value
	/// </summary>
	public class HueModifier 
	{
		private int hue = 0;

		// Hue property
		public int Hue
		{
			get { return hue; }
			set { hue = Math.Max( 0, Math.Min( 359, value ) ); }
		}

		// Constructor
		public HueModifier( )
		{
		}
		public HueModifier( int hue )
		{
			this.hue = hue;
		}

	
		// Apply filter
		public Bitmap Apply( Bitmap srcImg )
		{
			if ( srcImg.PixelFormat != PixelFormat.Format24bppRgb )
				throw new ArgumentException( );

			// get source image size
			int width = srcImg.Width;
			int height = srcImg.Height;

			// lock source bitmap data
			BitmapData srcData = srcImg.LockBits(
				new Rectangle( 0, 0, width, height ),
				ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb );

			// create new image
			Bitmap dstImg = new Bitmap( width, height, PixelFormat.Format24bppRgb );

			// lock destination bitmap data
			BitmapData dstData = dstImg.LockBits(
				new Rectangle( 0, 0, width, height ),
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb );

			// copy image
			Win32.memcpy( dstData.Scan0, srcData.Scan0, srcData.Stride * height );

			// process the filter
			ProcessFilter( dstData );

			// unlock both images
			dstImg.UnlockBits( dstData );
			srcImg.UnlockBits( srcData );

			return dstImg;
		}

       

		// Apply filter on current image
		public void ApplyInPlace( Bitmap img )
		{
			if ( img.PixelFormat != PixelFormat.Format24bppRgb )
				throw new ArgumentException( );

			// get source image size
			int width = img.Width;
			int height = img.Height;

			// lock source bitmap data
			BitmapData data = img.LockBits(
				new Rectangle( 0, 0, width, height ),
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb );

			// process the filter
			ProcessFilter( data );

			// unlock image
			img.UnlockBits( data );
		}


		// Process the filter
		private unsafe void ProcessFilter( BitmapData data )
		{
			int width	= data.Width;
			int height	= data.Height;

			RGB		rgb = new RGB( );
			HSL		hsl = new HSL( );
			int		offset = data.Stride - width * 3;

			// do the job
			byte * ptr = (byte *) data.Scan0.ToPointer( );

			// for each row
			for ( int y = 0; y < height; y++ )
			{
				// for each pixel
				for ( int x = 0; x < width; x++, ptr += 3 )
				{
					rgb.Red		= ptr[RGB.R];
					rgb.Green	= ptr[RGB.G];
					rgb.Blue	= ptr[RGB.B];

					// convert to HSL
					ColorConverter.RGB2HSL( rgb, hsl );

					// modify Hue value
					hsl.Hue = hue;

					// convert back to RGB
					ColorConverter.HSL2RGB( hsl, rgb );

					ptr[RGB.R] = rgb.Red;
					ptr[RGB.G] = rgb.Green;
					ptr[RGB.B] = rgb.Blue;
				}
				ptr += offset;
			}
		}
	}
}
