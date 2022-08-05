
function findCountry(inputCountry) {
    if (inputCountry != '' && inputCountry != null) {
        $.ajax({
            url: '/Country/Get/' + inputCountry,
            type: 'GET',
            dataType: 'json',
            success: function (result) {

                if (result != null) {
                    $("#countryId").val(result.id);
                    $('#selectedCountry').val(result.name);
                    $('#inputCountry').val('');
                    $('#inputCountry').attr("placeholder", "Знайти назву країни");
                }
                else {
                    $("#inputCountry").val('');
                    $('#inputCountry').attr("placeholder", "В базі данних мемає такої країни");
                }
            },
            error: function () {
                alert('findCountry ajax - error connection');
            }
        });
    }
}

function findGenre(inputGenre) {
    if (inputGenre != '' && inputGenre != null) {
        $.ajax({
            url: '/Genre/Get/' + inputGenre,
            type: 'GET',
            dataType: 'json',
            success: function (result) {

                if (result != null) {
                    var item = "<div class='input-group mb-2' id='genreBlock'>";
                    item += "<input  value='" + result.name + "' class='form-control' readonly>";
                    item += "<span class='btn btn-danger' id='removeGenre' type='button'>Вилучити</span>";
                    item += "<div>";
                    item += "<input name='[]GenresIds' value='" + result.id + "' type='hidden'  readonly>";
                    item += "</div>";
                    item += "</div>";

                    $("#genreBlock:last").before(item);
                    $("#inputGenre").val('');
                    $('#inputGenre').attr("placeholder", "Знайти жанр");
                }
                else {
                    $("#inputGenre").val('');
                    $('#inputGenre').attr("placeholder", "В базі данних мемає такого жанру");
                }
            },
            error: function () {
                alert('findGenre ajax - error connection');
            }
        });
    }
}

function findPerson(inputPerson) {
    if (inputPerson != '' && inputPerson != null) {
        $.ajax({
            url: '/Person/Get/' + inputPerson,
            type: 'GET',
            dataType: 'json',
            success: function (result) {

                if (result != null) {
                    if (roleSelect.value != "Роль") {

                        var item = "<div class='input-group mb-2' id='personBlock'>";
                        item += "<input class='form-control' value='" + result.firstName + " " + result.lastName + "' id='selectedPerson' readonly>";
                        item += "<input class='form-control' value='" + roleSelect.value + "'id='selectedRolePerson' readonly>";
                        item += "<span class='btn btn-danger' id='removePerson' type='button'>Вилучити</span>";
                        item += "<div>";
                        item += "<input name='[]PersonsIds' value='" + result.id + "' type='hidden'  readonly>";
                        item += "<input name='[]RolePersons' value='" + roleSelect.value + "' type='hidden'  readonly>";
                        item += "</div>";
                        item += "</div>";

                        $("#personBlock:last").before(item);
                        $("#inputPerson").val('');
                        $('#inputPerson').attr("placeholder", "Знайти персону за ім'ям або прізвищем");
                    }
                    else {
                        alert("Роль персонажа не обрана");
                    }
                }
                else {
                    $("#inputPerson").val('');
                    $('#inputPerson').attr("placeholder", "В базі данних мемає такго персони");
                }
            },
            error: function () {
                alert('findPerson ajax - error connection');
            }
        });
    }
}

function loadCertifications() {
    $.ajax({
        url: '/Certificate/GetList',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            var block = "<select name='CertificateId' class='form-select'>";

            result.forEach(certificate => 
                block += "<option value='" + certificate.id + "'>" + certificate.name + "</option>"
            );

            block += "</select>";
            $("#certificateBlock:last").before(block);
        },
        error: function () {
            alert('loadCertifications ajax - error connection');
        }
    });
}
