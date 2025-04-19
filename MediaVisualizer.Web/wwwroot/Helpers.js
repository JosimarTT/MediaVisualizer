function setVideoSource(videoElementId, videoUrl) {
    let videoElement = document.getElementById(videoElementId);
    if (videoElement) {
        videoElement.src = videoUrl;
    }
}