YUserAPI
==================================================================

------------------------------------------------------------------
Методы
------------------------------------------------------------------

.. code-block:: csharp

   public Task AuthorizeAsync(AuthStorage storage, string token)

Авторизация с использованием токена.

.. warning:: Необходимо обязательно выполнить авторизацию перед использованием функционала API.
 
.. code-block:: csharp

   public Task<YResponse<YAccountResult>> GetUserAuthAsync(AuthStorage storage)

Получение информации об аккаунте.

.. code-block:: csharp

   public Task<YAuthTypes> CreateAuthSessionAsync(AuthStorage storage, string userName)

Создание сеанса и получение доступных методов авторизации.

.. code-block:: csharp

   public Task<string> GetAuthQRLinkAsync(AuthStorage storage)

Получение ссылки на QR-код.

.. code-block:: csharp

   public Task<YAuthQRStatus> AuthorizeByQRAsync(AuthStorage storage)

Авторизация по QR-коду.

.. code-block:: csharp

   public Task<YAuthCaptcha> GetCaptchaAsync(AuthStorage storage)

Получение данных captcha.

.. code-block:: csharp

   public Task<YAuthBase> AuthorizeByCaptchaAsync(AuthStorage storage, string captchaValue)

Авторизация по captcha.

.. code-block:: csharp

   public Task<YAuthLetter> GetAuthLetterAsync(AuthStorage storage)

Получение письма авторизации на почту пользователя.

.. code-block:: csharp

   public Task<bool> AuthorizeByLetterAsync(AuthStorage storage)

Авторизация после подтверждения входа через письмо.

.. code-block:: csharp

   public Task<YAuthBase> AuthorizeByAppPasswordAsync(AuthStorage storage, string password)

Авторизация с помощью пароля из приложения Яндекс.

.. code-block:: csharp

   public Task<YAccessToken> GetAccessTokenAsync(AuthStorage storage)

Получение YAccessToken после авторизации с помощью QR, e-mail, пароля из приложения.

.. code-block:: csharp

   public Task<YLoginInfo> GetLoginInfoAsync(AuthStorage storage)

Получение информации о пользователе через логин Яндекса.