//Custom Message Uploader
pluploadMessage = {
	FILE_EXTENSION_ERROR: 'File extension error.',
	FILE_SIZE_ERROR: 'File size must be less than 1 mb.',
	FILE_DUPLICATE_ERROR: 'Duplicate file error.',
	INIT_ERROR: 'Init error.',
	HTTP_ERROR: 'HTTP Error.',
	CANNOT_BE_FOUND: "'%' specified, but cannot be found.",
	BROWSE_BUTTON_OR_DROP_ELEMENT: "You must specify either 'browse_button' or 'drop_element'."
}
//End Custom Message Uploader

//Singel Upload With Button
function singleUploaded(mimeTypes, browseButton, url, container, showResult, error, chunkSize, maxFileSize, isOneFile) {
    //debugger;
    if (maxFileSize == undefined) {
        maxFileSize = '2GB';
    }
    if (chunkSize == undefined) {
        chunkSize = '1mb';
    }
    var uploader = new plupload.Uploader({
        browse_button: browseButton, // you can pass in id...
        url: url,
        runtimes: 'html5,silverlight,html4',
        container: document.getElementById(container), // ... or DOM Element itself
        chunk_size: chunkSize,
        unique_names: false,
        filters: {
            mime_types: mimeTypes,
            max_file_size: maxFileSize,
            prevent_duplicates: true,
            drop_element: false

        },
        // Flash settings
        flash_swf_url: 'scripts/plupload/js/Moxie.swf',

        init: {
            FilesAdded: function (up, files) {
                uploader.start();
            },
            FileUploaded: function (up, file, response) {
                $('<span>' +
                    '<span class="fileName">' + file.name + '</span>' +
                    '<a href="#" class="ui-button-icon ui-icon ui-icon-trash" onclick="Delete(this)" data-file="' + file.name + '" ></a>' +
                '</span>'
                ).appendTo(showResult);
                if (isOneFile == true)
                    up.trigger("DisableBrowse", true);
            },

            ChunkUploaded: function (up, file, info) {
                // Called when file chunk has finished uploading
                // log('[ChunkUploaded] File:', file, "Info:", info);
            },
            Error: function (up, err) {
                // Called when error occurs
                //debugger;
                // I'm online so submit the form.
                log('[Error] ', err);
                //debugger;
                //$("<label style='color:red'>" + err.message + err.file.name.split('.').pop() + "</label>").appendTo(error);
                $(error).html("<label style='color:red'>" + err.message + "</label>");
                $('input', showResult).val(null);
                up.refresh();
            },
            //Delete: function (obj) {
            //    var filename = $(obj).attr("data-file");
            //    $.ajax({
            //        url: '/upload/Delete?fileName=' + filename,
            //        type: 'POST',
            //        contentType: 'application/json; charset=utf-8',
            //        success: function (data) {
            //            $(obj).parent().remove();
            //        },
            //        error: function () {
            //            alert("Error");
            //        }
            //    });
            //}
        }
    });
    uploader.init();
    return uploader;
}
//End Singel Upload With Button

//Multi and single Upload Drag and Drop
function multiUploaded(mimeTypes, browseButton, url, showResult, error, chunkSize, maxFileSize, isSingleUpload) {
	if (isSingleUpload == undefined) {
		isSingleUpload = false;
	}
	if (maxFileSize == undefined) {
	    maxFileSize = '1mb';
	}
	if (chunkSize == undefined) {
		chunkSize = '1mb';
	}
	$(browseButton).plupload({
		// General settings
		runtimes: 'html5,gears,flash,silverlight,browserplus,html4',
		url: url,

		//sample size 204800b or 200kb
		chunk_size: chunkSize,
		unique_names: false,

		// Specify what files to browse for
		filters: {
			mime_types: mimeTypes,
			max_file_size: maxFileSize,
			prevent_duplicates: true,
			drop_element: false

		},
		multi_selection: (!isSingleUpload),
		// Rename files by clicking on their titles
		rename: true,

		// Sort files
		sortable: true,
		views: {
			list: true,
			thumbs: true, // Show thumbs
			active: 'thumbs'
		},
		// Flash settings
		flash_swf_url: '/plupload/js/Moxie.swf',

		// Silverlight settings
		silverlight_xap_url: '/plupload/js/Moxie.xap',
		init: {
			StateChanged: function (up) {
				if (up.state === plupload.STOPPED) {
					//debugger;
					$('#tempFail').val('').hide();
				}
			},
			ChunkUploaded: function (up, file, info) {
				// Called when file chunk has finished uploading
				// log('[ChunkUploaded] File:', file, "Info:", info);
			},
			Error: function (up, args) {
				// Called when error occurs
				if (navigator.onLine) {
					// I'm online so submit the form.
					log('[Error] ', args);
				}
			},
			QueueChanged: function (up) {
				if (isSingleUpload && up.files.length > 0) {
					var firstFile = up.files[0].name;
					if (up.files.length > 1) {
						alert('You can not add more than one file!');
						$.each(up.files, function (i, file) {
							if (file && file.name != firstFile) {
								up.removeFile(file);
							}
						});
					}
				}
			}
		}
	});
}
//End Multi and single Upload Drag and Drop

//log
function log() {
	var str = "";
	//debugger;
	plupload.each(arguments, function (arg) {
		var row = "";

		if (typeof (arg) != "string") {
			plupload.each(arg, function (value, key) {
				// Convert items in File objects to human readable form
				if (arg instanceof plupload.File) {
					// Convert status to human readable
					switch (value) {
						case plupload.QUEUED:
							value = 'QUEUED';
							break;

						case plupload.UPLOADING:
							value = 'UPLOADING';
							break;

						case plupload.FAILED:
							value = 'FAILED';
							break;

						case plupload.DONE:
							value = 'DONE';
							break;
					}
				}

				if (typeof (value) != "function") {
					row += (row ? ', ' : '') + key + '=' + value;
				}
			});

			str += row + " ";
		} else {
			str += arg + " ";
		}
	});
	//var log = document.getElementById('console');
    //log.innerHTML += str + "\n";
	console.log(str + "\n");
}
//end log

//Deletefile
function Delete(obj) {
    var filename = $(obj).attr("data-file");
    $.ajax({
        url: '/upload/Delete?fileName=' + filename,
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            $(obj).parent().remove();
        },
        error: function () {
            alert("Error");
        }
    });
}
//Deletefile