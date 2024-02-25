using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;

namespace PenghuSpace.lib
{
    public class RecyclerViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Caption { get; set; }
        public TextView Count { get; set; }
        public RecyclerViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            // Locate and cache view references:
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
            Count = itemView.FindViewById<TextView>(Resource.Id.textView2);
            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
    class RecyclerViewAdapter : RecyclerView.Adapter
    {
        private List<Data> datas = new List<Data>();
        public event EventHandler<int> ItemClick;
        public RecyclerViewAdapter(List<Data> datas)
        {
            this.datas = datas;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item, parent, false);
            RecyclerViewHolder viewholder = new RecyclerViewHolder(itemView, OnClick);
            return viewholder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder viewholder = holder as RecyclerViewHolder;
            viewholder.Image.SetImageResource(datas[position].imageId);
            viewholder.Caption.Text = datas[position].caption;
            viewholder.Count.Text = datas[position].count;
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
        public void DatasAdd(int imageId, string caption, string count)
        {
            datas.Add(new Data() { imageId = imageId, caption = caption, count = count });
            NotifyDataSetChanged();
        }
        public void DatasClear()
        {
            datas.Clear();
        }
        public List<Data> DatasGet()
        {
            return datas;
        }
    }

    class Data
    {
        public int imageId { get; set; }
        public string caption { get; set; }
        public string count { get; set; }
    }
}