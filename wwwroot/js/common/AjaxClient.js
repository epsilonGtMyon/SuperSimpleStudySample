const AjaxClient = (function () {
  return class AjaxClient {
    static get(url, data) {
      Loading.show();
      return new Promise((resolve, reject) => {
        $.ajax({
          url: `${ROOT_URL}${url}`,
          method: "GET",
          data: data,
        }).then(
          //成功時
          (data, textStatus, jqXHR) => {
            Loading.hide();
            resolve(data);
          },
          //失敗時
          (jqXHR, textStatus, errorThrown) => {
            Loading.hide();
            reject(errorThrown);
          }
        );
      });
    }

    static post(url, data) {
      Loading.show();
      return new Promise((resolve, reject) => {
        $.ajax({
          url: `${ROOT_URL}${url}`,
          method: "POST",
          data: data,
        }).then(
          //成功時
          (data, textStatus, jqXHR) => {
            Loading.hide();
            resolve(data);
          },
          //失敗時
          (jqXHR, textStatus, errorThrown) => {
            Loading.hide();
            reject(errorThrown);
          }
        );
      });
    }
  };
})();
