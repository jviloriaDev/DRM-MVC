/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.removeButtons = 'Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField';

    config.extraPlugins = 'uploadimage';
    config.extraPlugins = 'uploadwidget';
    config.extraPlugins = 'filetools';
    config.extraPlugins = 'widget';
    config.extraPlugins = 'notificationaggregator';
    config.extraPlugins = 'notification';
    config.extraPlugins = 'filebrowser';
    config.extraPlugins = 'popup';
};
