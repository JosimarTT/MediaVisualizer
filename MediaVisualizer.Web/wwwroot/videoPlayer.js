function setVideoSource(videoElementId, videoUrl) {
    var videoElement = document.getElementById(videoElementId);
    if (videoElement) {
        videoElement.src = videoUrl;
    }
}