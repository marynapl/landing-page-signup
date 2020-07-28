var subscribe = subscribe ? subscribe : function () {
    var settings = {
        api: '/api/signup',
        submitButton: '#subscribeButton',
        emailElement: '#userEmail',
        nameElement: '#userName',
        messageElement: '#message',
        successElement: '#success',
    }

    function init() {
        $(settings.submitButton).on('click', function (e) {
            e.preventDefault();
            submit();
        });

        $(settings.submitButton).on('keypress', function (e) {
            if (e.which && e.which === 13 ||
                e.keyCode && e.keyCode === 13) {
                submit();
            }
        });
    }

    function submit() {
        // Clear errors
        clearErrors();

        // Validate the form
        var isValid = validate();
        if (!isValid) {
            return;
        }

        // Get form data
        var data = {
            name: $(settings.nameElement).val(),
            email: $(settings.emailElement).val()
        };

        $(settings.submitButton).attr('disabled', true);

        // Submit data
        var promise = save(data);
        $.when(promise).done(function (result) {
            clear();
            $(settings.successElement).removeClass('d-none');
            $(settings.submitButton).removeAttr('disabled');
        }).fail(function (jqxhr, textStatus, error) {
            console.log('Server error ', error);
            clear();
            $(settings.submitButton).removeAttr('disabled');
        });
    }

    function save(data) {
        return $.ajax({
            url: settings.api,
            data: JSON.stringify(data),
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json'
        });
    }

    function validate() {
        var isValid = true;
        var name = $(settings.nameElement).val();
        if (name.length <= 0) {
            $(settings.nameElement).addClass('is-invalid');
            isValid = false;
        }

        var email = $(settings.emailElement).val();
        if (email.length <= 0) {
            $(settings.emailElement).addClass('is-invalid');
            $(settings.emailElement).next('.invalid-feedback').text('Email is required');
            isValid = false;
        } else {
            var mailformat = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if (!email.match(mailformat)) {
                $(settings.emailElement).addClass("is-invalid");
                $(settings.emailElement).next('.invalid-feedback').text('Email is invalid');
                isValid = false;
            }
        }
        return isValid;
    }

    function clear() {
        clearErrors();
        $(settings.emailElement).val('');
        $(settings.nameElement).val('');
    }

    function clearErrors() {
        $(settings.emailElement).removeClass("is-invalid");
        $(settings.nameElement).removeClass("is-invalid");
        $(settings.successElement).addClass('d-none');
    }

    return {
        init: init,
        clear: clear
    };
}();

