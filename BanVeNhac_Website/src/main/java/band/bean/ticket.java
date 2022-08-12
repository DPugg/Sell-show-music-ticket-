package band.bean;

public class ticket {
	private String loaiVe;
	private float giaVe;
	private int soLuong;
	private String SDT;
	private float tongTien;
	
	
	public ticket() {
		super();
	}


	public ticket(String loaiVe, float giaVe, int soLuong, String sDT, float tongTien) {
		super();
		this.loaiVe = loaiVe;
		this.giaVe = giaVe;
		this.soLuong = soLuong;
		this.SDT = sDT;
		this.tongTien = tongTien;
	}


	public String getLoaiVe() {
		return loaiVe;
	}


	public void setLoaiVe(String loaiVe) {
		this.loaiVe = loaiVe;
	}


	public float getGiaVe() {
		return giaVe;
	}


	public void setGiaVe(float giaVe) {
		this.giaVe = giaVe;
	}


	public int getSoLuong() {
		return soLuong;
	}


	public void setSoLuong(int soLuong) {
		this.soLuong = soLuong;
	}


	public String getSDT() {
		return SDT;
	}


	public void setSDT(String sDT) {
		SDT = sDT;
	}


	public float getTongTien() {
		return tongTien;
	}


	public void setTongTien(float tongTien) {
		this.tongTien = tongTien;
	}
	
	
	
}
