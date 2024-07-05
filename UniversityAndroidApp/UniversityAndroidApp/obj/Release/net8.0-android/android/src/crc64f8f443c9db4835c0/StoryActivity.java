package crc64f8f443c9db4835c0;


public class StoryActivity
	extends crc64f8f443c9db4835c0.StoryBase
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("PenghuSpace.Activity.StoryActivity, UniversityAndroidApp", StoryActivity.class, __md_methods);
	}


	public StoryActivity ()
	{
		super ();
		if (getClass () == StoryActivity.class) {
			mono.android.TypeManager.Activate ("PenghuSpace.Activity.StoryActivity, UniversityAndroidApp", "", this, new java.lang.Object[] {  });
		}
	}


	public StoryActivity (int p0)
	{
		super (p0);
		if (getClass () == StoryActivity.class) {
			mono.android.TypeManager.Activate ("PenghuSpace.Activity.StoryActivity, UniversityAndroidApp", "System.Int32, System.Private.CoreLib", this, new java.lang.Object[] { p0 });
		}
	}


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
