namespace E_Learn.Common.Domain;

public class VideoResponse {

    public string filename { get; }
    public long size { get; }
    public double duration { get; }

    

    public VideoResponse(string filename, long size, double duration) {

        this.filename = filename;
        this.size = size;
        this.duration = duration;
    }

}