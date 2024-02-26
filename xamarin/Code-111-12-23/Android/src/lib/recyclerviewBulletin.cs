using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;

namespace PenghuSpace.lib
{
    public class RecyclerViewHolderBulletin : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public TextView Count { get; set; }
        public RecyclerViewHolderBulletin(View itemView, Action<int> listener) : base(itemView)
        {
            // Locate and cache view references:
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
    class RecyclerViewAdapterBulletin : RecyclerView.Adapter
    {
        private List<Bulletin> datas = new List<Bulletin>();
        public event EventHandler<int> ItemClick;
        public RecyclerViewAdapterBulletin(List<Bulletin> datas)
        {
            this.datas = datas;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Bulletin, parent, false);
            RecyclerViewHolderBulletin viewholder = new RecyclerViewHolderBulletin(itemView, OnClick);
            return viewholder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolderBulletin viewholder = holder as RecyclerViewHolderBulletin;
            viewholder.Image.SetImageResource(datas[position].imageId);
            viewholder.Caption.Text = datas[position].caption;
        }
        public override int ItemCount
        {
            get { return datas.Count; }

        }
        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
        public void DatasAdd(int imageId, string caption)
        {
            datas.Add(new Bulletin() { imageId = imageId, caption = caption });
            NotifyDataSetChanged();
        }
        public void DatasClear()
        {
            datas.Clear();
        }
        public List<Bulletin> DatasGet()
        {
            return datas;
        }
    }

    class Bulletin
    {
        public int imageId { get; set; }
        public string caption { get; set; }
    }
}