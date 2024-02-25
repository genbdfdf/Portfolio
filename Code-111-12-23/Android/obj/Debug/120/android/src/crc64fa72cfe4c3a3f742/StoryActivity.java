package crc64fa72cfe4c3a3f742;


public class StoryActivity
	extends crc64fa72cfe4c3a3f742.StoryBase
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("PenghuSpace.Activity.StoryActivity, PenghuSpace", StoryActivity.class, __md_methods);
	}


	public StoryActivity ()
	{
		super ();
		if (getClass () == StoryActivity.class) {
			mono.android.TypeManager.Activate ("PenghuSpace.Activity.StoryActivity, PenghuSpace", "", this, new java.lang.Object[] {  });
		}
	}


	public StoryActivity (int p0)
	{
		super (p0);
		if (getClass () == StoryActivity.class) {
			mono.android.TypeManager.Activate ("PenghuSpace.Activity.StoryActivity, PenghuSpace", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
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
