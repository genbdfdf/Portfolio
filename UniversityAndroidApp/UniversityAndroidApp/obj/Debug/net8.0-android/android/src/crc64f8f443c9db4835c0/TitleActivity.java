package crc64f8f443c9db4835c0;


public class TitleActivity
	extends androidx.appcompat.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onStart:()V:GetOnStartHandler\n" +
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("PenghuSpace.Activity.TitleActivity, UniversityAndroidApp", TitleActivity.class, __md_methods);
	}


	public TitleActivity ()
	{
		super ();
		if (getClass () == TitleActivity.class) {
			mono.android.TypeManager.Activate ("PenghuSpace.Activity.TitleActivity, UniversityAndroidApp", "", this, new java.lang.Object[] {  });
		}
	}


	public TitleActivity (int p0)
	{
		super (p0);
		if (getClass () == TitleActivity.class) {
			mono.android.TypeManager.Activate ("PenghuSpace.Activity.TitleActivity, UniversityAndroidApp", "System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0 });
		}
	}


	public void onStart ()
	{
		n_onStart ();
	}

	private native void n_onStart ();


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
