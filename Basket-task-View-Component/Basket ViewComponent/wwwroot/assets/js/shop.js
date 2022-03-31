$(document).ready(function () {
  $("i").click(function () {
    $(".ul").removeClass("d-none");
    $(".ul").addClass("d-block");
  });
  $("i").mouseleave(function () {
    $(".ul").removeClass("d-block");
    $(".ul").addClass("d-none").hide(2000);
  });
  $("#1").click(function () {
    $(".count-categories").addClass("d-none");
    $(".sort-categories").addClass("d-block");
    $(".sort-categories").removeClass("d-none");
    $(".sort-categories").slideToggle(1000);
  });
  $("#2").click(function () {
    $(".sort-categories").addClass("d-none");
    $(".count-categories").removeClass("d-none");
    $(".count-categories").addClass("d-block");
    $(".count-categories").slideToggle(1000);
  });
});
$(document).ready(function () {
  $("h6").click(function () {
    $(".sort-categories").removeClass("d-none")
    $(".sort-categories").addClass("active");
  });
  $("h6").mouseleave(function () {
    $(".sort-categories").removeClass("active");
    $(".sort-categories").addClass("d-none")

  });
  $("#h6").click(function () {
    $(".count-categories").removeClass("d-none")
    $(".count-categories").addClass("active");
  });
  $("#h6").mouseleave(function(){
    $(".count-categories").removeClass("active");
    $(".count-categories").addClass("d-none")
  })
});
