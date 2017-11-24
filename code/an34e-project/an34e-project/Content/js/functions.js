
$(document).ready(function () {
    $('#tableCustomers')/*.DataTable()*/;
    $('#tableEvaluations')/*.DataTable()*/;
    $('#tableQuestion')/*.DataTable()*/;
    $('#divShowCustomer').hide();
    $('#divShowArea').hide();
    $('#divShowQuestion').hide();

    $('#btnAdd').click(function () {
        if (validate() == false)
            return;
        $.ajax({
            url: '/Customer/SaveCustomer',
            type: 'POST',
            data: {
                id: $("#id").val(),
                name: $("#name").val(),
                responsible: $("#responsible").val()
            },
            error: function () {
                alert("Não foi possível realizar a operação!\nHouve um problema no envio da sua requisição!");

            },
            success: function (data) {
                if (data.success == true) {
                    alert("Cliente cadastrado com sucesso")
                    window.location.replace("/Home/Customers?IdArea=-1");
                }
                else {
                    alert("Houve um problema ao registrar o Cliente!");
                }

            }
        });
    });
});

function setIdModal(idArea) {
    $('#idArea').val(idArea);
}

function btnAddEvaluation() {
    //alert($("#idArea").val());
    $.ajax({
        url: '/Evaluation/SaveEvaluation',
        type: 'POST',
        data: {
            teste: $("#idArea").val(),
            month: $("#month").val(),
            year: $("#year").val(),

        },
        error: function () {
            alert("Não foi possível realizar a operação!\nHouve um problema no envio da sua requisição!");

        },
        success: function (data) {

            if (data.HasEvaluation == true) {
                alert("Avaliação não foi registrada!\nVerifique já existe uma avaliação em andamento para esta área.\nVerifique se já existe uma avaliação cadastrada para o mês selecionado.");
                return;

            }
            if (data.Save == false) {
                alert("Houve um problema ao registrar a Avaliação!");
            }
            else if (data.Save == true) {
                alert("Avaliação cadastrada com sucesso!");
                window.location.replace("/Home/Evaluation");
            }

        }
    });

    //$.ajax({
    //    url: '/Evaluation/SaveEvaluation',
    //    type: 'POST',
    //    data: {
    //        id: idArea,
    //        month: $("#month").val(),
    //        year: $("#year").val(),

    //    },
    //    error: function () {
    //        alert("Não foi possível realizar a operação!\nHouve um problema no envio da sua requisição!");

    //    },
    //    success: function (data) {
    //        if (data.success == true) {
    //            alert("Avaliação cadastrada com sucesso")
    //            // $.post("/Home/Customers", { IdArea: 2 }, function (data) { $("#modalCustomer").modal("hide"); });
    //            window.location.replace("/Home/Evaluation");
    //        }
    //        else {
    //            alert("Houve um problema ao registrar a Avaliação!");
    //        }

    //    }
    //});
    //});
}



function validate() {

    if ($("#title").val() == "" || $("#title").val() == "" || $("#responsible").val() == ""
        || $("#email").val() == "" || $("#phone").val() == "" || $("#area").val() == "") {
        //demo.showNotification('top', 'center');
        alert("Todos os campos são obrigatórios, por favor preencha-os!");
        return false;
    }


}

var currentCustomer = 0;
function ShowCustomer(IdCustomer) {
    $.ajax({
        url: '/Customer/GetCustomerEdit',
        type: 'POST',
        data: { Id: IdCustomer, },
        error: function () {
            alert("Não foi possível realizar a operação!");

        },
        success: function (customer) {


            $('#divShowCustomer').show();//exibe div com botoes

            var obj = JSON.parse(customer);
            currentCustomer = obj.Id;
            $('#titleShow').val(obj.Title);
            $('#responsibleShow').val(obj.Responsible);
            $('#emailShow').val(obj.Email);
            $('#phoneShow').val(obj.Phone);

            $('#areaShow').val(obj.Area.Title);

        }
    });
}



function editCustomer() {

    $.ajax({
        url: '/Customer/GetCustomerEdit?id=' + currentCustomer,
        type: 'GET',
        //data: { Id: IdCustomer },
        error: function () {
            alert("Não foi possível realizar a operação!");

        },
        success: function (customer) {


            $("#modalCustomer").modal(); //abre a modal

            var obj = JSON.parse(customer);
            $('#id').val(obj.Id);
            $('#title').val(obj.Title);
            $('#responsible').val(obj.Responsible);
            $('#email').val(obj.Email);
            $('#phone').val(obj.Phone);
            //$('#since').val(obj.Since);
            $('#area').val(obj.Area.Title);

        }
    });
}

function showModal() {
    clearForm();
}

function clearForm() {
    $('#id').val('0');
    $('#title').val('');
    $('#responsible').val('');
    $('#email').val('');
    $('#phone').val('');
    //$('#area').val('');
}

function deleteCustomer() {
    alert("Tem certeza que deseja remover esse Cliente?\nEssa opção não poderá ser desfeita.")
    $.ajax({
        url: '/Customer/DeleteCustomer?id=' + currentCustomer,
        type: 'POST',
        //data: { Id: IdCustomer },
        error: function () {
            alert("Não foi possível realizar a operação!");

        },
        success: function (data) {
            if (data.success) {
                alert("Cliente removido com sucesso.");
                window.location.replace("/Home/Customers?IdArea=-1");
            } else {
                alert("Houve um problema ao excluir o Cliente!");
            }
        }
    });
}

demo = {
    showNotification: function (from, align) {

        color = 1;

        $.notify({
            icon: "pe-7s-attention",
            message: "Welcome to <b>Light Bootstrap Dashboard</b> - a beautiful freebie for every web developer."

        }, {
            type: type[color],
            timer: 4000,
            placement: {
                from: from,
                align: align
            }
        });
    }
}

var currentQuestion = 0;
function ShowQuestion(IdQuestion) {
    $.ajax({
        url: '/Question/Edit',
        type: 'POST',
        data: { Id: IdQuestion, },
        error: function () {
            alert("Não foi possível realizar a operação!");

        },
        success: function (question) {


            $('#divShowQuestion').show();//exibe div com botoes

            var obj = JSON.parse(question);
            currentQuestion = obj.Id;
            $('#PerguntaShow').val(obj.Quest);
            $('#NivelShow').val(obj.Level);
            $('#NivelNecessarioShow').val(obj.RequiredLevel);

        }
    });
}

function editQuestion() {

    $.ajax({
        url: '/Question/SelectById?id=' + currentQuestion,
        type: 'GET',
        //data: { Id: IdCustomer },
        error: function () {
            alert("Não foi possível realizar a operação!");

        },
        success: function (customer) {


            $("#modalCustomer").modal(); //abre a modal

            var obj = JSON.parse(customer);
            $('#id').val(obj.Id);
            $('#title').val(obj.Title);
            $('#responsible').val(obj.Responsible);
            $('#email').val(obj.Email);
            $('#phone').val(obj.Phone);
            //$('#since').val(obj.Since);
            $('#area').val(obj.Area.Title);

        }
    });
}

function btnAddQuestion() {
    //alert($("#idArea").val());
    $.ajax({
        url: '/Question/Insert',
        type: 'POST',
        data: {
            Quest: $("#question").val(),
            Level: $("#level").val(),
            RequiredLevel: $("#required_lever").val(),

        },
        error: function () {
            alert("Não foi possível realizar a operação!\nHouve um problema no envio da sua requisição!");

        },
        success: function (data) {
            if (data == "{success:True}") {
                alert("Pergunta cadastrada com sucesso!");
                window.location.replace("/Home/Question");
            } else
                alert("Deu Ruim!");

        }
    });

    //$.ajax({
    //    url: '/Evaluation/SaveEvaluation',
    //    type: 'POST',
    //    data: {
    //        id: idArea,
    //        month: $("#month").val(),
    //        year: $("#year").val(),

    //    },
    //    error: function () {
    //        alert("Não foi possível realizar a operação!\nHouve um problema no envio da sua requisição!");

    //    },
    //    success: function (data) {
    //        if (data.success == true) {
    //            alert("Avaliação cadastrada com sucesso")
    //            // $.post("/Home/Customers", { IdArea: 2 }, function (data) { $("#modalCustomer").modal("hide"); });
    //            window.location.replace("/Home/Evaluation");
    //        }
    //        else {
    //            alert("Houve um problema ao registrar a Avaliação!");
    //        }

    //    }
    //});
    //});
}