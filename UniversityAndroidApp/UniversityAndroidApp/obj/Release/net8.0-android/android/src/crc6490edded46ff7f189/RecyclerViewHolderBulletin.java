package crc6490edded46ff7f189;


public class RecyclerViewHolderBulletin
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("PenghuSpace.lib.RecyclerViewHolderBulletin, UniversityAndroidApp", RecyclerViewHolderBulletin.class, __md_methods);
	}


	public RecyclerViewHolderBulletin (android.view.View p0)
	{
		super (p0);
		if (getClass () == RecyclerViewHolderBulletin.class) {
			mono.android.TypeManager.Activate ("PenghuSpace.lib.RecyclerViewHolderBulletin, UniversityAndroidApp", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}

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
